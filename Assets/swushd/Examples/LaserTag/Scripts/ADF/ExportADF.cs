using UnityEngine;
using System.Collections;

public class ExportADF : MonoBehaviour {
	 Tango.AreaDescription[] areas;
	// Use this for initialization
	void Start () {
		FindObjectOfType<Tango.TangoApplication>().RegisterPermissionsCallback(_OnPermissionsCallback);
	}
	
	void _OnPermissionsCallback(bool granted) {
		if(granted) {
			areas = Tango.AreaDescription.GetList();
			foreach(var area in areas) {
				ADFManager.Export(area.m_uuid);
			}
		}
	}
	
	void OnGUI()
	{
		GUI.TextArea(Rect.MinMaxRect(0,Screen.height-20,400,Screen.height), ADFManager.ExportPath);
		
		int count = 1;
		foreach(var area in areas) {
			GUI.TextArea(Rect.MinMaxRect(0,Screen.height-20+count*20,400,Screen.height+20*count), ADFManager.ExportPath);
			count++;
		}
	}
}
