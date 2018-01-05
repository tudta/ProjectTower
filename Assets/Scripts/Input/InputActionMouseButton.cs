using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InputActionMouseButton : InputAction {
    [SerializeField] [Range(0,2)] private int button = 0;
    [SerializeField] private ButtonInputTypes inputType;

    public int Button {get{return button;} set{button = value;}}
    public ButtonInputTypes InputType {get{return inputType;} set{inputType = value;}}
}
