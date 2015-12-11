using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {
    public Slider energyBar;
	// Use this for initialization
    public float value;
	void Start () {
        energyBar = GetComponent<Slider>();
        value = LaserBeam.energyValue;
	}
	
	// Update is called once per frame
	void Update () {
        value = LaserBeam.energyValue;
        energyBar.value = value;
	}
}
