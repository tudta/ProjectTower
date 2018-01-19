using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class UISlider : MonoBehaviour {
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
        
    }
}
