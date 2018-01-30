using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleButton : UIButton {
    [SerializeField] private List<GameObject> targetButtons = new List<GameObject>();

    public override void Awake() {
        base.Awake();
    }

    public override void OnClick() {
        ToggleButtons();
    }

    private void ToggleButtons() {
        foreach (GameObject btn in targetButtons) {
            if (btn.activeSelf) {
                btn.SetActive(false);
            }
            else {
                btn.SetActive(true);
            }
        }
    }
}
