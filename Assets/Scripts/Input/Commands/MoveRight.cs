using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Commands/MoveRight", fileName = "SOMoveRight")]
public class MoveRight : Command {
    public override void Execute() {
        Player.Instance.Move(Vector3.right);
    }
}
