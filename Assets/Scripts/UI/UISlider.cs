﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class UISlider : UIElement {
    private Slider slider = null;

    public virtual void Awake() {
        Init();
    }

	// Use this for initialization
	public virtual void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

    public virtual void Init() {
        slider = gameObject.GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnValueChange);
    }

    public virtual void OnValueChange(float value) {
        Debug.LogWarning("Base method OnValueChange of UISlider called.");
    }

    public override void Show() {
        base.Show();
    }

    public override void OnShown() {
        base.OnShown();
    }

    public override void Hide() {
        base.Hide();
    }

    public override void OnHidden() {
        base.OnHidden();
    }

    public override void Enable() {
        slider.interactable = true;
    }

    public override void OnEnabled() {
        base.OnEnabled();
    }

    public override void Disable() {
        slider.interactable = false;
    }

    public override void OnDisabled() {
        base.OnDisabled();
    }
}
