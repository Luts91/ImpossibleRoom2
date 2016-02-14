using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
	public MeshRenderer mat;
	public Transform cam;
	public GameObject selectionPlane;
	public List<Monster> monsters=new List<Monster>();

	// Use this for initialization
	void Start () {
		OVRTouchpad.Create();
		OVRTouchpad.TouchHandler += HandleTouchHandler;

	}

	void HandleTouchHandler (object sender, System.EventArgs e)
	{
		OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;

		if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Down)
			TranslateBox (0.5f);
		if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Up)
			TranslateBox (-0.5f);
		if (touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
			CreateMonster ();

			
	}

	void TranslateBox(float strength){
		RaycastHit hit = new RaycastHit();
		Vector3 forward = Reticle.getInstance().transform.TransformDirection (Vector3.forward);


		Ray castedRay = new Ray (Vector3.zero, forward);
		if(Physics.Raycast(castedRay, out hit)) {
			SmoothMove sm = hit.collider.GetComponent<SmoothMove> ();
			if (sm) {
				sm.target = sm.target + hit.normal * strength;
			}
		}
	}

	void CreateMonster(){
		RaycastHit hit = new RaycastHit();
		Vector3 forward = Reticle.getInstance().transform.TransformDirection (Vector3.forward);
	

		Ray castedRay = new Ray (Vector3.zero, forward);
		if(Physics.Raycast(castedRay, out hit)) {
			Vector3 angle=new Vector3 (90, 180, 180);
			if (hit.normal.z < -0.1)
				angle = new Vector3 (-90, 0, 0);
			if (hit.normal.z > 0.1)
				angle = new Vector3 (90, 180, 180);
			if (hit.normal.y >0.1)
				angle = new Vector3 (0, 0, 0);
			if (hit.normal.y < -0.1)
				angle = new Vector3 (180, 0, 0);
			if (hit.normal.x > 0.1)
				angle = new Vector3 (90, 0, -90);
			if (hit.normal.x <-0.1)
				angle = new Vector3 (270, 0, 90);
			//Debug.Log (hit.normal.x+","+hit.normal.y+","+hit.normal.z + " " + angle);

			Instantiate (monsters[Random.Range(0,monsters.Count)], hit.point-forward*0.1f, Quaternion.Euler(angle));
		}
	}


	
	// Update is called once per frame
	void Update () {
		RaycastHit hit = new RaycastHit();
		Vector3 forward = Reticle.getInstance().transform.TransformDirection (Vector3.forward);


		Ray castedRay = new Ray (Vector3.zero, forward);
		if(Physics.Raycast(castedRay, out hit)) {
			Reticle.getInstance ().transform.localPosition = new Vector3 (0, 0, hit.point.magnitude-0.1f);	

			SmoothMove sm = hit.collider.GetComponent<SmoothMove> ();
			if (sm) {
				selectionPlane.SetActive (true);
				selectionPlane.transform.position = hit.collider.transform.position+hit.normal*0.51f;
				Vector3 angle=new Vector3 (90, 180, 180);
				if (hit.normal.z < -0.1)
					angle = new Vector3 (-90, 0, 0);
				if (hit.normal.z > 0.1)
					angle = new Vector3 (90, 180, 180);
				if (hit.normal.y > 0.1)
					angle = new Vector3 (0, 0, 0);
				if (hit.normal.y < -0.1)
					angle = new Vector3 (180, 0, 0);
				if (hit.normal.x > 0.1)
					angle = new Vector3 (90, 0, -90);
				if (hit.normal.x <-0.1)
					angle = new Vector3 (270, 0, 90);
				selectionPlane.transform.rotation = Quaternion.Euler (angle);
			} else {
				selectionPlane.SetActive (false);
			}
		}
	}
}
