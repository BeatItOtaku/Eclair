using UnityEngine;
using System.Collections;

public class ETO : MonoBehaviour {

	GameObject target = null;
	public GameObject player;
	public GameObject lightning;
	public InputManager im;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag ("Bolt");
		transform.LookAt (target.transform);
				transform.position += transform.forward * Time.deltaTime * 50;
	
	}
	private void OnCollisionEnter (Collision collider)
	{
			if (collider.gameObject.tag == "Bolt") {
				Instantiate (lightning, transform.position, transform.rotation);
				im.Idle ();
				Destroy (target);
			//InputManager.etoile = false;
			//InputManager.player_ =(GameObject)Instantiate (player, transform.position, transform.rotation);
			}			

	}
}
