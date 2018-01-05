using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InputAction))]
public class InputActionEditor : Editor {
    private int index = 0;
    private string[] commands = new string[] { "Move", "DoNothing" };
    private List<Type> tmpTypes = new List<Type>();
    private List<Type> desiredTypes = new List<Type>();

    private void OnEnable() {
        ReloadList();
    }

    public override void OnInspectorGUI() {
        EditorGUILayout.LabelField("Bleh");
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Cmd"));
        index = EditorGUILayout.Popup("Command", index, commands, EditorStyles.popup);
        serializedObject.ApplyModifiedProperties();
        Debug.Log(commands.Length);
    }

    private void ReloadList() {
        commands = null;
        tmpTypes.AddRange(Assembly.GetExecutingAssembly().GetTypes());
        desiredTypes.AddRange((from Type type in tmpTypes where type.IsSubclassOf((typeof(Command))) select type).ToArray());
        commands = desiredTypes.Select(I => I.Name).ToArray();
        Debug.Log(commands.Length);
    }
}