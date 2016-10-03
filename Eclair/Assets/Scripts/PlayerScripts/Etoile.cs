using UnityEngine;
using System.Collections;

public class Etoile : MonoBehaviour {

	public GameObject lightning;
	public GameObject player;
	GameObject target = null;

	GameObject FindClosestBolt(){

		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("Bolt");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;

		foreach (GameObject go in gos) {

			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;

			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}					


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {		
		if (Input.GetButtonDown ("Etoile")) {
			target = FindClosestBolt ();
		}
		
			if (target != null) {
				transform.LookAt (target.transform);
				transform.position += transform.forward * Time.deltaTime * 50;		
			}
	}
	
		private void OnCollisionEnter(Collision collider){			
		if (/*collider.gameObject.tag == "NoMoveBolt" ||*/collider.gameObject.tag =="Bolt") {
			Instantiate (lightning, transform.position, transform.rotation);
				Destroy (target);
			}
		}
	}
	