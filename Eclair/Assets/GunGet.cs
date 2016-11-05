using UnityEngine;
using System.Collections;

public class GunGet : MonoBehaviour {

	public EventManager em;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag == "Player"){
			if (EventManager.eventCount == 5) {
				em.EventCount ();
			}
	}	
}
}
