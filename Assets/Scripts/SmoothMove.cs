using UnityEngine;
using System.Collections;

public class SmoothMove : MonoBehaviour {

	public Vector3 target;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x + Random.value / 1000, transform.position.y + Random.value / 1000, transform.position.z + Random.value / 1000);


		target = transform.position;

		startPos = target;
	}
	
	// Update is called once per frame
	void Update () {
		if (target.magnitude < 1)
			return;

		if (Mathf.Abs ((transform.position - target).sqrMagnitude) > 0.01f) {
			transform.position = transform.position + (target - transform.position) / 20+(target-transform.position).normalized*0.01f;
		} else {
			transform.position = target;
		}


	}

	public void Restart(){
		target = startPos;
	}
}
