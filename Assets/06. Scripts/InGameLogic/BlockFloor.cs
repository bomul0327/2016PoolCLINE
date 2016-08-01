using UnityEngine;
using System.Collections;

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
        for(int i = 0; i < blockArray.Length; i++) {
            blockArray[i] = transform.GetChild(i).gameObject;
            block[i] = blockArray[i].GetComponent<Block>();
        }
	}

    public void SetBlocksBreakable(bool param) {
        for(int i = 0; i < block.Length; i++) {
            block[i].IsBreakable = param;
        }
    }

    public void SetBlocksHp(int minRange, int maxRange) {
        for(int i = 0; i < block.Length; i++) {
            block[i].Hp = Random.Range(minRange, maxRange);
        }
    }

    public void SetBlocksActive(bool param) {
        for(int i = 0; i < block.Length; i++) {
            blockArray[i].SetActive(param);
        }
    }
}
