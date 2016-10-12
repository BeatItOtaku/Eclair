using UnityEngine;
using System.Collections;

public class ETO : MonoBehaviour {

	GameObject target = null;
	public GameObject player;
	public GameObject lightning;
	public InputManager im;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.etoile == true) {
			target = player.GetComponent<LockOn> ().getCurrentTarget ();
			if (target != null) {
				transform.LookAt (target.transform);
				transform.position += transform.forward * Time.deltaTime * 50;
			}
		}
	}
	private void OnCollisionEnter (Collision collider)
	{
			if (collider.gameObject.tag == "Bolt") {			
			player.transform.position = target.transform.position;
				Instantiate (lightning, transform.position, transform.rotation);
				Destroy (target);
			InputManager.etoile = false;
			im.Idle ();
			gameObject.SetActive (false);
			Destroy (InputManager.eto_);
			}			

	}
}
