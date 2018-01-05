using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit {
    private static Player instance = null;

    public static Player Instance { get { return instance; } set { instance = value; } }

    public override void Awake() {
        base.Awake();
    }

    // Use this for initialization
    public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    public override void Init() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        GameManager.Instance.PlayerUnit = this;
        base.Init();
    }

    public void LookAtCursor() {
        //Rotate whatever needs to be rotated (head, arms, etc.) so that the player unit is looking at the cursor
    }
}
