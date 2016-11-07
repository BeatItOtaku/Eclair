using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	private Animator animator;
	public static bool doorOpen;

	public EventManager2 em2;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		doorOpen = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (doorOpen == true) {
			animator.SetTrigger ("Open");
			if (em2.eventCount2 == 2) {
				em2.EventCount2 ();
			}
	}
}
}
