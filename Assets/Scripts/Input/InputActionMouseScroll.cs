using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InputActionMouseScroll : InputAction {
    [SerializeField] private bool detectUpScroll = false;

    public bool DetectUpScroll {get{return detectUpScroll;} set{detectUpScroll = value;}}
}
