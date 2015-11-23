using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CachePlayerPrefab : NetworkBehaviour {
    public override void OnStartLocalPlayer() {
        base.OnStartLocalPlayer();

        StaticSyncUI.SetPlayer(this);
    }

    void Start() {
        Debug.Log("You are player " + playerControllerId);
    }

    public void resetPosition() {
        Debug.Log("Resetting Position");
        transform.position = playerControllerId * new Vector3(0.2f, 0, 0);
        transform.rotation = Quaternion.identity;
    }
}
