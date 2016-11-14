using UnityEngine;
using System.Collections;

public class FloorAboveEclair : MonoBehaviour {

	public GameObject eclair = null;

	private Vector3 position;

	// Use this for initialization
	void Start () {
		eclair = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		eclair = GameObject.FindGameObjectWithTag ("Player");
		if (eclair == null) {
			eclair = GameObject.FindGameObjectWithTag ("ETOEclair");
		}
		position = eclair.transform.position;
		position.y = 0;
		gameObject.transform.position = position;

	
	}
}
