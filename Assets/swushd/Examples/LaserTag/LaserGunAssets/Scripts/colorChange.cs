using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class colorChange : MonoBehaviour {

	// Use this for initialization
    private Image image;
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Shoot.isOnShoot)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.blue;
        }
	}
}
