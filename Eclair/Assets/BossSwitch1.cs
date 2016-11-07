using UnityEngine;
using System.Collections;

public class BossSwitch1 : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisonEnter(Collision collider){
		if (collider.gameObject.tag == "Player") {
			anim.SetTrigger ("SwtichOn");
		}
	}
}
