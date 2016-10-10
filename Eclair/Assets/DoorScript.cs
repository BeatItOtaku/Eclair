using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	private Animator animator;
	public static bool open;
	private bool firstOpen;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		open = false;
		firstOpen = false; 
		animator.SetBool ("FirstOpen", false);

	}
	
	// Update is called once per frame
	void Update () {

		if (open == true) {
			animator.SetBool ("FirstOpen", true);
			firstOpen = true;
			if(firstOpen == true){
				animator.SetBool("Open",true);
			}
		}
		if (firstOpen == true) {
			if (open == false) {
				animator.SetBool ("Open", false);
			}
		}
	}
}
