using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimationQueue_Play : AnimationQueueBase {

	// Use this for initialization
	void Start () {
		GetComponent<Image> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public override void Queue(){
		//Debug.Log ("aho");
		GetComponent<Image> ().enabled = true;
		GetComponent<Animation> ().Play ();
	}
}
