using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour {
	public float speed=0.1f;
	float coolDown=0;
	RaycastHit lastHit;

	float dirChange=5;

	public static List<Monster> monsters = new List<Monster> ();
	public static int maxCount=20;

	// Use this for initialization
	void Start () {

		monsters.Add (this);

		if (monsters.Count >= maxCount) {
			Destroy (monsters [0].gameObject);
			monsters.RemoveAt (0);
		}



		int rot = Random.Range (-2, 2);
		transform.Rotate (new Vector3(0,rot*90,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (coolDown > 0)
			coolDown -= Time.deltaTime;

		dirChange -= Time.deltaTime;
		if (dirChange <= 0) {
			int rot = Random.Range (-1, 2);
			transform.Rotate (new Vector3(0,rot*90,0));
			dirChange = 5+Random.value*5;
		}

		transform.Translate (Vector3.forward*Time.deltaTime*speed);

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, 0.1f)) {
			transform.Rotate (new Vector3 (-90, 0));
		}else if (coolDown<=0 && !Physics.Raycast (transform.position+transform.up*0.1f, -transform.up,0.21f)) {
			transform.Translate (-Vector3.up * 0.1f);
		}else if (coolDown<=0 && !Physics.Raycast (transform.position+transform.forward*0.1f, -transform.up, 0.2f)) {
			coolDown = 2;
			transform.Translate (Vector3.forward * 0.2f);
			transform.Rotate (new Vector3 (90, 0));
		}

	}
}
