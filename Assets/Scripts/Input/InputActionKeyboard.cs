using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InputActionKeyboard : InputAction {
    [SerializeField] private KeyCode key;
    [SerializeField] private ButtonInputTypes inputType;

    public KeyCode Key {get{return key;} set{key = value;}}
    public ButtonInputTypes InputType {get{return inputType;} set{inputType = value;}}
}
