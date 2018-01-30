using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackScreenButton : UIButton {

    public override void Awake() {
        base.Awake();
    }

    public override void OnClick() {
        UIManager.Instance.GoBack();
    }
}
