using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private Transform SpawnPos;
    [SerializeField]
    private Transform BreakablePos;
    [SerializeField]
    private Transform FadePos;
    [SerializeField]
    private GameObject[] BlockFloor;

    private bool isMoving = false;

    //UI score
    private InGameScore scoreUI;
  

    //To UI: IsPaused = true/false; 를 설정하게 하시면 됩니다.

    private bool isPaused = false;
    public bool IsPaused {
        get {
            return isPaused;
        }
        set {
            isPaused = value;
        }
    }

    void Start () {
        for(int i = 0; i < BlockFloor[1].transform.childCount; i++) {
            BlockFloor[1].transform.GetChild(i).GetComponent<Block>().IsBreakable = true;
        }
        for(int i = 0; i < BlockFloor.Length; i++) {
            for(int j = 0; j < BlockFloor[i].transform.childCount; j++) {
                BlockFloor[i].transform.GetChild(j).GetComponent<Block>().Hp = 1;
            }
        }
        //UI score
        scoreUI = GameObject.Find("Score").GetComponent<InGameScore>();

    }

    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 100f);

            if(hit.collider != null && hit.transform.CompareTag("Block")) {
                Block hitBlock = hit.transform.GetComponent<Block>();
                if (hitBlock.IsBreakable == true) {
                    hitBlock.Hp--;
                    if(hitBlock.Hp <= 0) {
                        hitBlock.gameObject.SetActive(false);

                        //UI Score 스코어 점수 1이 올라가게 되어있습니다. 사용하시는 곳에다가 쓰시면 됩니다~ 
                        scoreUI.displayscore(1);                  

                        for(int i = 0; i < BlockFloor.Length; i++) {
                            iTween.MoveBy(BlockFloor[i], iTween.Hash("y", -2.00f, "time"
                                , 1.0f, "delay", 0.5f
                                ,"oncomplete", "OnMove"
                                , "oncompletetarget", this.gameObject));
                        }
                    }
                }
            }
        }
    }
    void OnMove () {
        
        OnBlockBreakablePosition();
        OnBlockMoveToSpawnPosition();
    }
    void OnBlockMoveToSpawnPosition () {
        Debug.Log("a");
        for(int i = 0; i < BlockFloor.Length; i++) {
            int tmpFadePosY = (int)Mathf.Round(FadePos.transform.position.y * 100f);
            int blockFloorPosY = (int)Mathf.Round(BlockFloor[i].transform.position.y * 100f);
            BlockFloor[i].transform.position = new Vector3(0, blockFloorPosY * 0.01f, 0);
            if(tmpFadePosY == blockFloorPosY) {
                BlockFloor[i].transform.position = SpawnPos.position;
                for (int j = 0; j < BlockFloor[i].transform.childCount; j++) {
                    BlockFloor[i].transform.GetChild(j).GetComponent<Block>().IsBreakable = false;
                    if (!BlockFloor[i].transform.GetChild(j).gameObject.activeInHierarchy) {
                        BlockFloor[i].transform.GetChild(j).gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    void OnBlockBreakablePosition () {
        Debug.Log("b");
            for (int i = 0; i < BlockFloor.Length; i++) {
                int tmpBreakPosY = (int)Mathf.Round(BreakablePos.transform.position.y * 100f);
                int blockFloorPosY = (int)Mathf.Round(BlockFloor[i].transform.position.y * 100f);
            BlockFloor[i].transform.position = new Vector3(0, blockFloorPosY * 0.01f, 0);
            if (tmpBreakPosY == blockFloorPosY) {
                    for(int j = 0; j < BlockFloor[i].transform.childCount; j++) {
                    BlockFloor[i].transform.GetChild(j).GetComponent<Block>().IsBreakable = true;
                    }
                }
            }
        }
}
