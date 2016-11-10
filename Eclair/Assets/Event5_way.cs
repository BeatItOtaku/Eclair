using UnityEngine;
using System.Collections;

public class Event5_way : MonoBehaviour {

	public GameObject fire;

	public EventManager2 em2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (em2.eventCount2 == 5) {
			Instantiate (fire, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	
	}
}
