using UnityEngine;
using System.Collections;

public class StepSound : MonoBehaviour {
	public AudioClip l,r;
	bool left=true;
	AudioSource a;

	// Use this for initialization
	void Start () {
		a = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play(){
		if (left)
			a.clip = l;
		else
			a.clip = r;

		a.Play ();



		left = !left;
	}
}
