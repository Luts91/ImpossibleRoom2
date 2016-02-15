using UnityEngine;
using System.Collections;

public class FlyAround : MonoBehaviour {

	public float speed=10;
	public float rotate=10;

	public bool test=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector3.forward*Time.deltaTime*speed);
		transform.Rotate (new Vector3 (0, Time.deltaTime*rotate, 0));
		//transform.position = new Vector3 (Mathf.Sin (Time.time),transform.position.y, Mathf.Cos (Time.time));
			
		if (test) {
			test = false;
			Absturz ();
		}
	}

	public void Absturz(){
		transform.Rotate (new Vector3 (-90, 0, 0));
		Destroy (gameObject, 2);
	}
}
