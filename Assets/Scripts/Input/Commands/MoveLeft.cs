using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Commands/MoveLeft", fileName = "SOMoveLeft")]
public class MoveLeft : Command {
    public override void Execute() {
        Player.Instance.Move(Vector3.left);
    }
}
