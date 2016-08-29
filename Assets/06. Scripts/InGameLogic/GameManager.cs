using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BlockType = Block.BlockType;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private Transform spawnPos;
    [SerializeField]
    private Transform breakablePos;
    [SerializeField]
    private Transform fadePos;
    [SerializeField]
    private Transform waterInitPos;
    [SerializeField]
    private Transform waterEndPos;
    [SerializeField]
    private BlockFloor[] blockFloor;
    [SerializeField]
    private GameObject water;
    [SerializeField]
    private AudioClip hitSound;

    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float waterSpeed = 5.0f;
    [SerializeField]
    private int blockHpMinRange = 1;
    [SerializeField]
    private int blockHpMaxRange = 5;

    [SerializeField]
    private InGameUI UIMgr;

    [Header("Level Balance Variables")]
    [SerializeField]
    private int maxCycle = 3;
    [SerializeField]
    private int minCycle = 6;
    [SerializeField]
    private int waterSpeedCycle = 10;

    [Space(10)]


    private bool isMoving = false;
    private bool isPaused = false;
    public bool IsPaused {
        get {
            return isPaused;
        }
        set {
            isPaused = value;
        }
    }

    private int currentScore = 0;
    private int numBlockFloorCreated = 0;
    private int breakableIndex = 1;

    private Stack<IEnumerator> blockStack;
    private AudioSource audioSource;

    void Start () {
        blockStack = new Stack<IEnumerator>();
        audioSource = GetComponent<AudioSource>();

        blockFloor[1].SetBlocksBreakable(true);
        for (int i = 0; i < blockFloor.Length; i++) {
            blockFloor[i].SetBlocksProperty(BlockType.bomb, 20);
            blockFloor[i].SetBlocksHp(blockHpMinRange, blockHpMaxRange);
            numBlockFloorCreated++;
            StartCoroutine(SettingLevel(numBlockFloorCreated));
        }
        OnWaterMoveComplete();
    }

    void Update () {
        if (isPaused) return;
        StartCoroutine(OnMouseClicked());
        StartCoroutine(BlockStatusCheck());
        UIMgr.DisplayWaterDistance(Vector2.Distance(water.transform.position, waterEndPos.position));
    }

    IEnumerator OnMouseClicked () {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 100f);

            if (hit.collider && hit.transform.CompareTag("Block")) {
                Block hitBlock = hit.transform.GetComponent<Block>();

                if (hitBlock.IsBreakable) {
                    hitBlock.Hp--;
                    iTween.ShakePosition(hitBlock.gameObject, iTween.Hash("name", "blockShake"
                        , "x", 0.1f
                        , "y", 0.1f
                        , "time", 0.05f
                        , "oncomplete", "hitBlock.ResetInitPos"
                        , "oncompletetarget", hitBlock.gameObject));
                    audioSource.PlayOneShot(hitSound);

                    if (hitBlock.Hp <= 0) {
                        BlockFloor hitBlockFloor = hitBlock.GetComponentInParent<BlockFloor>();
                        for (int i = 0; i < hitBlockFloor.Block.Length; i++) {
                            iTween.StopByName(hitBlockFloor.Block[i].gameObject, "blockShake");
                        }
                        hitBlockFloor.ResetLocalPosition();
                        hitBlockFloor.SetBlocksBreakable(false);
                        hitBlock.gameObject.SetActive(false);
                        if (hitBlock.BlockProperty == BlockType.bomb) {
                            UIMgr.OnGameOver();
                        }
                        blockStack.Push(BlockMove());
                    }
                }
            }
        }
        yield return null;
    }

    IEnumerator BlockStatusCheck () {
        if (blockStack.Count > 0 && !isMoving) {
            StartCoroutine(blockStack.Pop());
            StartCoroutine("WaterMove");
            isMoving = true;
        }
        yield return null;
    }

    IEnumerator BlockMove () {
        if(breakableIndex == blockFloor.Length - 1) {
            breakableIndex = 0;
        }
        else {
            breakableIndex++;
        }
        iTween.MoveBy(blockFloor[0].transform.root.gameObject, iTween.Hash("y", -2.0f
            , "time", speed
            , "onupdate", "OnBlockMoveUpdate"
            , "onupdatetarget", this.gameObject
            , "oncomplete", "OnBlockMoveComplete"
            , "oncompletetarget", this.gameObject));

        yield return null;
    }

    IEnumerator WaterMove () {
        iTween.StopByName(water, "waterMoveUp");
        iTween.MoveBy(water, iTween.Hash("y", -2.0f
            , "time", speed
            , "oncomplete", "OnWaterMoveComplete"
            , "oncompletetarget", this.gameObject));

        yield return null;
    }

    void OnBlockMoveUpdate () {
        for (int i = 0; i < blockFloor.Length; i++) {
            blockFloor[i].ResetLocalPosition();
            //Set Blocks to be breakable
            if (Vector2.Distance(blockFloor[i].transform.position, breakablePos.transform.position) < 0.1f) {
                if (breakableIndex == i) {
                    blockFloor[i].SetBlocksBreakable(true);
                }
                else {
                    blockFloor[i].SetBlocksBreakable(false);
                }
            }
        }
    }

    void OnBlockMoveComplete () {
        for (int i = 0; i < blockFloor.Length; i++) {
            //Blocks Move to Spawn Position
            if (Vector2.Distance(blockFloor[i].transform.position, fadePos.transform.position) < 0.1f) {
                blockFloor[i].transform.position = spawnPos.position;
                blockFloor[i].SetBlocksActive(true);
                blockFloor[i].ResetBlocksProperty();
                blockFloor[i].ResetLocalPosition();
                blockFloor[i].SetBlocksProperty(BlockType.bomb, 20);
                blockFloor[i].SetBlocksHp(blockHpMinRange, blockHpMaxRange);
            }
        }
        UIMgr.DisplayScore(++currentScore);
        numBlockFloorCreated++;
        StartCoroutine(SettingLevel(numBlockFloorCreated));
        isMoving = false;
    }

    void OnWaterMoveComplete () {
        iTween.MoveTo(water, iTween.Hash("name", "waterMoveUp"
            ,"position", waterEndPos
            , "speed", waterSpeed
            , "delay", 0.1f
            , "easetype", iTween.EaseType.linear
            , "oncomplete", "OnGameOver"
            , "oncompletetarget", UIMgr.gameObject));           
    }

    IEnumerator SettingLevel (int currentScore) {
        blockHpMaxRange =  5 + currentScore / maxCycle;
        blockHpMinRange = 1 + currentScore / minCycle;
        waterSpeed = 0.67f + ((currentScore / waterSpeedCycle));
        yield return null;
    }
}
