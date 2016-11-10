using UnityEngine;
using System.Collections;

public class BossGate : MonoBehaviour {

	private Animator anim;
	public EventManager2 em2;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (em2.bossSwitchCount == 2) {
			anim.SetTrigger ("Open");
			em2.EventCount2 ();
		}
	
	}
}
