﻿using UnityEngine;
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
        }
    }

    private int hp;
    public int Hp {
        get {
            return hp;
        }
        set {
            HpText.text = hp.ToString();
            hp = value;
        }
    }

    private bool isBreakable = false;
    public bool IsBreakable {
        get { return isBreakable; }
        set { isBreakable = value; }
    }

    public TextMesh HpText;

    void Start () {
        HpText = GetComponentInChildren<TextMesh>();
        HpText.text = Hp.ToString();
    }

}
