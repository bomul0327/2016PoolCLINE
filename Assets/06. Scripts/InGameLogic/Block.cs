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
            if(blockProperty == BlockType.bomb) {
                bombImage.SetActive(true);
                HpText.gameObject.SetActive(false);
            }
            else {
                bombImage.SetActive(false);
                HpText.gameObject.SetActive(true);
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
            HpText.text = hp.ToString();
        }
    }

    private bool isBreakable = false;
    public bool IsBreakable {
        get { return isBreakable; }
        set { isBreakable = value; }
    }

    public TextMesh HpText;

    [SerializeField]
    private GameObject bombImage;

    void Awake () {
        HpText.text = Hp.ToString();
    }

}
