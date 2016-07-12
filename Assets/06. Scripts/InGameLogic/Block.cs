using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    private int hp;
    public int Hp {
        get { return hp; }
        set { hp = value; }
    }

    private bool isBreakable = false;
    public bool IsBreakable {
        get { return isBreakable; }
        set { isBreakable = value; }
    }
}
