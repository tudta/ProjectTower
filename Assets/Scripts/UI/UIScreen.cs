using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class UIScreen : UIElement {
    private RectTransform rectTrans = null;
    private List<Transform> childTransforms = null;
    private List<UIElement> childUIElements = null;
    private Animator screenAnim = null;
    private int animParameterId = 0;
    private const string transitionParameterName = "IsOpen";
    private const string openedStateName = "Open";
    private const string closedStateName = "Closed";
    [SerializeField] private bool isPopup = false;

    public bool IsPopup {get{return isPopup;} set{isPopup = value;}}

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
        rectTrans = GetComponent<RectTransform>();
        if (rectTrans == null) {
            Debug.LogError("Error: No Rect Transform found on GameObject ' " + gameObject.name + "'");
        }
        childUIElements = new List<UIElement>(GetComponentsInChildren<UIElement>());
        childUIElements.Remove(this);
        screenAnim = GetComponent<Animator>();
        animParameterId = Animator.StringToHash(transitionParameterName);
    }

    public override void Show() {
        StartCoroutine(PlayShowScreenAnimation());
    }

    private IEnumerator PlayShowScreenAnimation() {
        screenAnim.SetBool(transitionParameterName, true);
        //yield return null;
        yield return new WaitForSeconds(screenAnim.GetCurrentAnimatorStateInfo(0).length);
        OnShown();
    }

    public override void OnShown() {
        foreach (UIElement element in childUIElements) {
            element.Enable();
        }
        base.OnShown();
    }

    public override void Hide() {
        StartCoroutine(PlayHideScreenAnimation());
    }

    private IEnumerator PlayHideScreenAnimation() {
        foreach (UIElement element in childUIElements) {
            element.Disable();
        }
        screenAnim.SetBool(transitionParameterName, false);
        //yield return null;
        yield return new WaitForSeconds(screenAnim.GetCurrentAnimatorStateInfo(0).length);
        OnHidden();
    }

    public override void OnHidden() {
        base.OnHidden();
    }

    public override void Enable() {
        foreach (UIElement element in childUIElements) {
            element.Enable();
        }
        base.Enable();
    }

    public override void OnEnabled() {
        base.OnEnabled();
    }

    public override void Disable() {
        foreach (UIElement element in childUIElements) {
            element.Disable();
        }
        base.Disable();
    }

    public override void OnDisabled() {
        base.OnDisabled();
    }
}
