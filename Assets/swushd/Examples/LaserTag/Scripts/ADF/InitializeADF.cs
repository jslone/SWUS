using UnityEngine;
using System.Collections;

public class InitializeADF : MonoBehaviour {
	public string uuid;
	
	private Tango.TangoApplication app;
	
	void Start() {
		app = FindObjectOfType<Tango.TangoApplication>();
		app.RegisterPermissionsCallback(_OnPermissionCallback);
	}
	
	void _OnPermissionCallback(bool granted) {
		if(granted) {
			app.InitProviders(uuid);
		}
	}
}
