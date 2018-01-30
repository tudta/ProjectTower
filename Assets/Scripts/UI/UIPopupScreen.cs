using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupScreen : UIScreen {

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    public override void Init() {
        base.Init();
    }

    public virtual void DisablePreviousPopupScreen() {

    }
}
