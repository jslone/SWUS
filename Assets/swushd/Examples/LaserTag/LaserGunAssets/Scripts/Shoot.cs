using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    static public bool isOnShoot;//shoot variable
	// Use this for initialization
    public delegate void ShootEventManager();
    static public ShootEventManager shootManagerEditor;
    static public ShootEventManager shootManagerTango;
	void Start () {
        isOnShoot = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!isOnShoot)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {

                shootManagerEditor();

            }
#else
        if (Input.touchCount == 1)
        {
         shootManagerTango();
        }
#endif
        }
    }
}


