using UnityEngine;
using System.Collections;

public class ImportADF : MonoBehaviour {
	public string[] uuids;
	
	// Use this for initialization
	void Start () {
		FindObjectOfType<Tango.TangoApplication>().RegisterPermissionsCallback(_OnPermissionsCallback);
	}
	
	void _OnPermissionsCallback(bool granted) {
		if(granted) {
			foreach(string uuid in uuids) {
				ADFManager.Import(uuid);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
