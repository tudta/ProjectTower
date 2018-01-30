using UnityEngine;

public abstract class UIElement : MonoBehaviour {
    public delegate void UIElementTransition();
    public event UIElementTransition OnUIElementShown;
    public event UIElementTransition OnUIElementHidden;
    public event UIElementTransition OnUIElementEnabled;
    public event UIElementTransition OnUIElementDisabled;

    public virtual void Show() {
        OnShown();
    }

    public virtual void OnShown() {
        //Debug.Log("UIElementShown event called!");
        if (OnUIElementShown != null) {
            OnUIElementShown();
        }
    }

    public virtual void Hide() {
        OnHidden();
    }

    public virtual void OnHidden() {
        //Debug.Log("UIElementHidden event called!");
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
        if (OnUIElementDisabled != null) {
            OnUIElementDisabled();
        }
    }
}
