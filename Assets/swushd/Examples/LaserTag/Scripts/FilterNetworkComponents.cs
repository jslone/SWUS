using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class FilterNetworkComponents : NetworkBehaviour {
	public Behaviour[] authorityBehaviours;
	
	public override void OnStartAuthority() {
		base.OnStartAuthority();
		foreach(var behaviour in authorityBehaviours) {
			behaviour.enabled = true;
		}
	}
}
