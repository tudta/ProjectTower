using UnityEngine;

public abstract class UIElement : MonoBehaviour {
    public Color enabledColor = Color.white;
    public Color disabledColor = Color.black;

    private bool isShown = false;
    private bool isEnabled = false;

    public delegate void UIElementTransition();
    public event UIElementTransition OnUIElementShown;
    public event UIElementTransition OnUIElementHidden;
    public event UIElementTransition OnUIElementEnabled;
    public event UIElementTransition OnUIElementDisabled;

    public virtual void Show() {
        gameObject.SetActive(true);
        OnShown();
    }

    public virtual void OnShown() {
        //Debug.Log("UIElementShown event called!");
        isShown = true;
        if (OnUIElementShown != null) {
            OnUIElementShown();
        }
    }

    public virtual void Hide() {
        gameObject.SetActive(false);
        OnHidden();
    }

    public virtual void OnHidden() {
        //Debug.Log("UIElementHidden event called!");
        isShown = false;
        if (OnUIElementHidden != null) {
            OnUIElementHidden();
        }
    }

    public virtual void Enable() {
        //Debug.LogWarning("Base UIElement Enable() called. No action possible.");
        OnEnabled();
    }

    public virtual void OnEnabled() {
        // Debug.Log("UIElementEnabled event called!");
        isEnabled = true;
        if (OnUIElementEnabled != null) {
            OnUIElementEnabled();
        }
    }

    public virtual void Disable() {
        //Debug.LogWarning("Base UIElement Disable() called. No action possible.");
        OnDisabled();
    }

    public virtual void OnDisabled() {
        //Debug.Log("UIElementDisabled event called!");
        isEnabled = false;
        if (OnUIElementDisabled != null) {
            OnUIElementDisabled();
        }
    }
}
