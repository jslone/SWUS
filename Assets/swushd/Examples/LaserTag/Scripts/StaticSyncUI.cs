using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaticSyncUI : MonoBehaviour {

    private static StaticSyncUI instance;
    private CachePlayerPrefab player;

    public Text buttonText;

    void Awake() {
        if (!instance) {
            instance = this;
        }
    }

    public void ResetPlayer() {
        Debug.Log(Time.time);
        if (player) {
            player.resetPosition();
        }
    }

    public static void SetPlayer(CachePlayerPrefab player) {
        instance.player = player;
    }
}
