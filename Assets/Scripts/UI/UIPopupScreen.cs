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

    public override void ShowScreen() {
        base.ShowScreen();
    }

    public override void ShowScreenDone() {
        base.ShowScreenDone();
    }

    public override void ShowScreenImmediate() {
        base.ShowScreenImmediate();
    }

    public override void HideScreen(Action onDoneCallback = null) {
        base.HideScreen();
    }

    public override void HideScreenDone() {
        base.HideScreenDone();
    }

    public override void HideScreenImmediate() {
        HideScreenImmediate();
    }
}
