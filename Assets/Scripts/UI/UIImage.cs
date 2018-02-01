using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIImage : UIElement {
    public Image img = null;

    public virtual void Awake() {
        Init();
    }

    // Use this for initialization
    public virtual void Start() {

    }

    // Update is called once per frame
    public virtual void Update() {

    }

    public virtual void Init() {
        img = gameObject.GetComponent<Image>();
        enabledColor = img.color;
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
        img.color = enabledColor;
        base.Enable();
    }

    public override void OnEnabled() {
        base.OnEnabled();
    }

    public override void Disable() {
        img.color = disabledColor;
        base.Disable();
    }

    public override void OnDisabled() {
        base.OnDisabled();
    }
}
