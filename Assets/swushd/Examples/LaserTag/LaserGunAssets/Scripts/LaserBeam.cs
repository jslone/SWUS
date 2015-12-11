using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

    public float speed = 0.1f;
    public Transform gunPoint;
    public LineRenderer lineRenderer;
    public Vector3 targetLoc = new Vector3(0,0,0);
    public Vector3 startLoc = new Vector3(0, 0, 0);
    public Vector3 targetDir = Vector3.forward;
	public float colorIntence = 0.3f;
    public static float energyValue;

    private int shootingFrames = 10;
	private AudioSource laserSound;
    private float distance;
    Camera cam;

    

   
	void Start () {
        
        cam = Camera.main;
        gunPoint = transform; //gunpoint position
        distance = speed * shootingFrames * 4.0f;
		laserSound = GetComponent<AudioSource>();
        lineRenderer = this.GetComponent<LineRenderer>();
		colorIntence = 0.3f;
        startLoc = this.transform.position;
        targetLoc = this.transform.position;
        lineRenderer.SetPosition(1,startLoc);
        lineRenderer.SetPosition(1,targetLoc);
        //register the onshoot functions
        Shoot.shootManagerEditor += ShootLaserEditor;
        Shoot.shootManagerTango += ShootLaserTango;

        energyValue = 1.0f;
	}
	
// Update is called once per frame
	void FixedUpdate () {
        UpdateLaser();  
	}

    void UpdateLaser()
    {
        lineRenderer.SetPosition(0, startLoc);
        lineRenderer.SetPosition(1, targetLoc);
        lineRenderer.material.SetColor("_TintColor", new Color(colorIntence, 0, 0));
    }

    void ShootLaserEditor()
    {
        Vector3 position = Input.mousePosition;//shift the position
        position = new Vector3(position.x, position.y, cam.nearClipPlane);
        position = cam.ScreenToWorldPoint(position);
        position = distance / cam.nearClipPlane * (position - cam.transform.position) + cam.transform.position;
        targetDir = position - gunPoint.position;
        targetDir.Normalize();
        
        Shoot.isOnShoot = true;
        laserSound.Play();
        StartCoroutine(OneShoot());
    }
    void ShootLaserTango()
    {
        Touch t = Input.GetTouch(0);
        
        Vector3 position = new Vector3(t.position.x,t.position.y, cam.nearClipPlane);
        position = cam.ScreenToWorldPoint(position);
        position = distance / cam.nearClipPlane * (position - cam.transform.position) + cam.transform.position;
        targetDir = position - gunPoint.position;
        targetDir.Normalize();

        Shoot.isOnShoot = true;
        laserSound.Play();
        StartCoroutine(OneShoot());
    }

    IEnumerator OneShoot()
    {   // origianl energy value drops to 0;
        energyValue = 0.0f;
        for (int i = 0; i < shootingFrames; i++)
        {   // Laser come out from the gun
            targetLoc += targetDir*speed;
			if (colorIntence<1) colorIntence+=0.07f;//color intence change
            energyValue += 0.025f;//magic number for energy change
            yield return null;
        }
        //second stage
        for (int i = 0; i < shootingFrames*3; i++)
        {
            startLoc += targetDir * speed;
            targetLoc += targetDir * speed;
            energyValue += 0.025f;//magic number for energy change
            yield return null;
        }
        startLoc = this.transform.position;   
        targetLoc = this.transform.position;
		colorIntence = 0.3f;
        Shoot.isOnShoot = false;
    }
}
