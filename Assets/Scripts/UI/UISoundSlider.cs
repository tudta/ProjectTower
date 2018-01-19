using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundSlider : UISlider {
    [SerializeField] private AudioManager.SoundTypes soundType = AudioManager.SoundTypes.NONE;

    public override void Awake() {
        base.Awake();
    }

    // Use this for initialization
    public override void Start () {
        base.Awake();
	}
	
    public override void OnValueChange(float value) {
        AudioManager.Instance.ChangeVolume(soundType, value);
    }
}
