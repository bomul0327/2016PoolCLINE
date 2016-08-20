using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    public enum BlockType {
        normal,
        bomb
    }
    private BlockType blockProperty;
    public BlockType BlockProperty {
        get {
            return blockProperty;
        }
        set {
            blockProperty = value;
            switch (blockProperty) {
                case BlockType.bomb:
                    bombImage.SetActive(true);
                    hpText.gameObject.SetActive(false);
                    break;

                case BlockType.normal:
                    bombImage.SetActive(false);
                    hpText.gameObject.SetActive(true);
                    break;
            }
        }
    }

    private int hp;
    public int Hp {
        get {
            return hp;
        }
        set {
            hp = value;
            hpText.text = hp.ToString();
        }
    }

    private bool isBreakable = false;
    public bool IsBreakable {
        get { return isBreakable; }
        set { isBreakable = value; }
    }

    [SerializeField]
    private TextMesh hpText;

    [SerializeField]
    private GameObject bombImage;

    void Awake () {
        hpText.text = hp.ToString();
    }

}
