using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Commands/Jump", fileName = "SOJump")]
public class Jump : Command {
    public override void Execute() {
        Player.Instance.Jump();
    }
}
