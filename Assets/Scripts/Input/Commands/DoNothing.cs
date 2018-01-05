using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObjects/Commands/DoNothing", fileName = "SODoNothing")]
//Empty command to be used by unbound keys
public class DoNothing : Command {
	public override void Execute() {}
}
