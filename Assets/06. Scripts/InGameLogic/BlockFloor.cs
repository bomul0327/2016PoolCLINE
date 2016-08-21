using UnityEngine;
using System.Collections;
using BlockType = Block.BlockType;

public class BlockFloor : MonoBehaviour {
    private GameObject[] blockArray;
    public GameObject[] BlockArray {
        get {
            return blockArray;
        }
    }
    private Block[] block;
    public Block[] Block {
        get {
            return block;
        }
    }

	void Awake () {
        blockArray = new GameObject[transform.childCount];
        block = new Block[blockArray.Length];
        for (int i = 0; i < blockArray.Length; i++) {
            blockArray[i] = transform.GetChild(i).gameObject;
            block[i] = blockArray[i].GetComponent<Block>();
        }
    }

    public void SetBlocksBreakable (bool param) {
        for (int i = 0; i < block.Length; i++) {
            block[i].IsBreakable = param;
        }
    }

    public void SetBlocksHp (int minRange, int maxRange) {
        for (int i = 0; i < block.Length; i++) {
            switch (block[i].BlockProperty) {
                case BlockType.normal:
                    int tmpHp = Random.Range(minRange, maxRange);
                    //체력이 같으면 다시 랜덤
                    for(int j = 0; j < i;) {
                        if(block[j].BlockProperty != BlockType.normal) {
                            j++;
                            continue;
                        }
                        else if(tmpHp == block[j].Hp) {
                            tmpHp = Random.Range(minRange, maxRange);
                            continue;
                        }
                        j++;
                    }
                    block[i].Hp = tmpHp;         
                    break;

                case BlockType.bomb:
                    block[i].Hp = 1;
                    break;
            }

        }
    }

    public void SetBlocksActive(bool param) {
        for(int i = 0; i < block.Length; i++) {
            blockArray[i].SetActive(param);
        }
    }

    //SetBlocksProperty should be used before the SetBlocksHp
    public void SetBlocksProperty (BlockType prop, int prob) {
        int propNum = 0;
        for (int i = 0; i < block.Length; i++) {
            if (propNum < block.Length - 1) {
                int randomNumber = Random.Range(1, 100);
                if (randomNumber <= prob) {
                    block[i].BlockProperty = prop;
                    propNum++;
                }
            }
        }
    }
    public void ResetBlocksProperty () {
        for(int i = 0; i < block.Length; i++) {
            block[i].BlockProperty = BlockType.normal;
        }
    }
}
