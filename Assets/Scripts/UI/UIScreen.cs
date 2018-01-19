using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour {
    protected RectTransform rectTrans = null;
    private List<Transform> childTransforms = null;

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
        childTransforms = new List<Transform>(GetComponentsInChildren<Transform>());
        childTransforms.Remove(transform);
        HideScreenImmediate();
    }

    public virtual void ShowScreen() {
        foreach (Transform childTrans in childTransforms) {
            childTrans.gameObject.SetActive(true);
        }
        ShowScreenDone();
    }

    public virtual void ShowScreenDone() {

    }

    public virtual void ShowScreenImmediate() {
        foreach (Transform childTrans in childTransforms) {
            childTrans.gameObject.SetActive(true);
        }
        ShowScreenDone();
    }

    public virtual void HideScreen(Action onDoneCallback = null) {
        foreach (Transform childTrans in childTransforms) {
            childTrans.gameObject.SetActive(false);
        }
        onDoneCallback();
        HideScreenDone();
    }

    public virtual void HideScreenDone() {
        
    }

    public virtual void HideScreenImmediate() {
        foreach (Transform childTrans in childTransforms) {
            childTrans.gameObject.SetActive(false);
        }
        HideScreenDone();
    }

    public virtual void DisableScreen() {
        
    }
}
