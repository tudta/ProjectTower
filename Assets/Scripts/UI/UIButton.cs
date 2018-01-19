using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class UIButton : MonoBehaviour {
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
        Debug.Log("Base Button OnClick");
    }

    public virtual void DisableButton() {
        button.interactable = false;
    }
}
