using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

    public float speed = 0.1f;
    public LineRenderer lineRenderer;
    public Vector3 targetLoc = new Vector3(0,0,0);
    public Vector3 startLoc = new Vector3(0, 0, 0);
    public Vector3 targetDir = Vector3.forward;
	public float colorIntence = 0.3f;
    private int shootingFrames = 10;
	private AudioSource laserSound;

   
	void Start () {
		laserSound = GetComponent<AudioSource>();
        lineRenderer = this.GetComponent<LineRenderer>();
		colorIntence = 0.3f;
        startLoc = this.transform.position;
        targetLoc = this.transform.position;
        lineRenderer.SetPosition(1,startLoc);
        lineRenderer.SetPosition(1,targetLoc);
	
	}
	
// Update is called once per frame
	void FixedUpdate () {
        UpdateLaser();
        lineRenderer.SetPosition(0, startLoc);
        lineRenderer.SetPosition(1, targetLoc);
		lineRenderer.material.SetColor("_TintColor",new Color(colorIntence,0,0));
	}
    void UpdateLaser()
    {
        laserSound.Play();
        Camera cam = Camera.main;
        //Debug Mode
     #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 position = Input.mousePosition;
            targetDir = cam.ScreenPointToRay(position).direction;
            ShootLaser();
        }
     #else
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            Vector2 guiPosition = new Vector2(t.position.x, Screen.height - t.position.y);
          
            if (t.phase != TouchPhase.Began)
            {
                return;
            }
            targetDir = cam.ScreenPointToRay(t.position).direction;
            ShootLaser();
        }
        #endif
    }

    void ShootLaser()
    {
        StartCoroutine(OneShoot());
    }

    IEnumerator OneShoot()
    {
        for (int i = 0; i < shootingFrames; i++)
        {   // Laser come out from the gun
            targetLoc += targetDir*speed;
			if (colorIntence<1) colorIntence+=0.07f;//color intence change
            yield return null;
        }
        //second stage
        for (int i = 0; i < shootingFrames*3; i++)
        {
            startLoc += targetDir * speed;
            targetLoc += targetDir * speed;
            yield return null;
        }
        startLoc = this.transform.position;   
        targetLoc = this.transform.position;
		colorIntence = 0.3f;
    }
}
