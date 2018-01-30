using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class UIButton : UIElement {
    public Button button = null;

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
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public virtual void OnClick() {
        Debug.LogWarning("Base Button OnClick");
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
        button.interactable = true;
    }

    public override void OnEnabled() {
        base.OnEnabled();
    }

    public override void Disable() {
        button.interactable = false;
    }

    public override void OnDisabled() {
        base.OnDisabled();
    }
}
