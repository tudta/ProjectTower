using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    private GameManager gm = null;
    [SerializeField] private List<InputActionMouseButton> mouseButtonActions = new List<InputActionMouseButton>();
    [SerializeField] private List<InputActionMouseScroll> mouseScrollActions = new List<InputActionMouseScroll>();
    [SerializeField] private List<InputActionMouseMovement> mouseMoveActions = new List<InputActionMouseMovement>();
    [SerializeField] private List<InputActionKeyboard> keyboardActions = new List<InputActionKeyboard>();
    private Vector3 lastMousePos = Vector3.zero;

    // Use this for initialization
    void Start() {
        Init();
    }

    private void Init() {
        gm = GameManager.Instance;
        lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update() {
        //MouseButton Check
        foreach (InputActionMouseButton action in mouseButtonActions) {
            if (action.InputType == ButtonInputTypes.DOWN) {
                if (Input.GetMouseButtonDown(action.Button)) {
                    if (gm.CurrentState == action.State) {
                        action.Cmd.Execute();
                    }
                }
            }
            else if (action.InputType == ButtonInputTypes.HOLD) {
                if (Input.GetMouseButton(action.Button)) {
                    if (gm.CurrentState == action.State) {
                        action.Cmd.Execute();
                    }
                }
            }
            else if (action.InputType == ButtonInputTypes.UP) {
                if (Input.GetMouseButtonUp(action.Button)) {
                    if (gm.CurrentState == action.State) {
                        action.Cmd.Execute();
                    }
                }
            }
        }

        //MouseScroll Check
        foreach (InputActionMouseScroll action in mouseScrollActions) {
            if (action.DetectUpScroll) {
                if (Input.GetAxis("Mouse ScrollWheel") > 0.0f) {
                    if (gm.CurrentState == action.State) {
                        action.Cmd.Execute();
                    }
                }
            }
            else if (!action.DetectUpScroll) {
                if (Input.GetAxis("Mouse ScrollWheel") < 0.0f) {
                    if (gm.CurrentState == action.State) {
                        action.Cmd.Execute();
                    }
                }
            }
        }

        //MouseMove Check
        foreach (InputActionMouseMovement action in mouseMoveActions) {
            if (Input.mousePosition != lastMousePos) {
                if (gm.CurrentState == action.State) {
                    action.Cmd.Execute();
                }
            }
        }
        lastMousePos = Input.mousePosition;

        //Keyboard Check
        foreach (InputActionKeyboard action in keyboardActions) {
            if (action.InputType == ButtonInputTypes.DOWN) {
                if (Input.GetKeyDown(action.Key)) {
                    if (gm.CurrentState == action.State) {
                        action.Cmd.Execute();
                    }
                }
            }
            else if (action.InputType == ButtonInputTypes.HOLD) {
                if (Input.GetKey(action.Key)) {
                    if (gm.CurrentState == action.State) {
                        action.Cmd.Execute();
                    }
                }
            }
            else if (action.InputType == ButtonInputTypes.UP) {
                if (Input.GetKeyUp(action.Key)) {
                    if (gm.CurrentState == action.State) {
                        action.Cmd.Execute();
                    }
                }
            }
        }
    }
}