using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CachePlayerPrefab : NetworkBehaviour {

    private Vector3 spawnPosition;

    public override void OnStartLocalPlayer() {
        base.OnStartLocalPlayer();

        StaticSyncUI.SetPlayer(this);
        spawnPosition = transform.position;
    }

    public void resetPosition() {
        Debug.Log("Resetting Position");
        transform.position = spawnPosition;
        transform.rotation = Quaternion.identity;
    }
}
