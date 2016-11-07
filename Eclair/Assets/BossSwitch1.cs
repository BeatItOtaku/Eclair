using UnityEngine;
using System.Collections;

public class BossSwitch1 : MonoBehaviour {

	private Animator anim;

	public EventManager2 em2;

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
			if (em2.eventCount2 == 4) {
				em2.EventCount2 ();
				em2.BossSwitch ();
			}
			if (em2.eventCount2 == 7) {
				em2.EventCount2 ();
				em2.BossSwitch ();
			}
		}
	}
}
