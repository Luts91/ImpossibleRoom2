using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(transform.localScale.x-Time.deltaTime/100,transform.localScale.y-Time.deltaTime/100,transform.localScale.z-Time.deltaTime/100);
		if (transform.localScale.x <= 0)
			Destroy (gameObject);
	}
}
