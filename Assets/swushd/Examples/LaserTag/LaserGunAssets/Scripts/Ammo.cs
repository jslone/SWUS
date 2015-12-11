using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ammo : MonoBehaviour {
    public int max_Ammo;
    private int ammoCount;
	// Use this for initialization
    public Text text;
    public void decreaseAmmo()
    {
        if(ammoCount>0)
        {
            ammoCount--;
            text.text = ammoCount.ToString("00");
        }
        
    }
	void Start () {
        ammoCount = max_Ammo;
        text = GetComponent<Text>();
        text.text = ammoCount.ToString("00");
        Shoot.shootManagerEditor+=decreaseAmmo;
        Shoot.shootManagerTango += decreaseAmmo;
	}
	
	// Update is called once per frame
	void Update () {
        if (ammoCount <= 0)
        {
            Shoot.isOnShoot = true;
        }
	}
}
