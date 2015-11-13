using UnityEngine;
using System.Collections;

class ADFManager {
	public static string ExportPath { get {return "/sdcard/Android/data/" + Application.bundleIdentifier + "/files";}}
	public static void Load(string uuid) {
		Tango.AreaDescription.ForUUID(uuid);
	}
	
	public static string Save() {
		return Tango.AreaDescription.SaveCurrent().m_uuid;
	}
	
	public static void Export(string uuid) {
		Tango.AreaDescription.ForUUID(uuid).ExportToFile(ExportPath);
	}
	
	public static void Import(string uuid) {
		Tango.AreaDescription.ImportFromFile(adfPath(uuid));
	}
	
	public static byte[] Read(string uuid) {
		return System.IO.File.ReadAllBytes(adfPath(uuid));
	}
	
	public static void Write(string uuid, byte[] bytes) {
		System.IO.File.WriteAllBytes(adfPath(uuid),bytes);
	}
	
	static string adfPath(string uuid) {
		return System.IO.Path.Combine(ExportPath, uuid);
	}
}