using UnityEngine;
using System.Collections;

public class BoltScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}

	public GameObject ShotPause;
	private GameObject shot;
	public PlayerShot playerShot;
	public GameObject lightning;
	public GameObject muzzle;

	public Vector3 Target {
		get;
		set;
	}


	// Update is called once per frame
	void Update () {
		//Destroy (gameObject, 3);
		//弾を前進させる
		//transform.position += transform.forward *Time.deltaTime * 70 ;
		Debug.Log(gameObject.transform.position);
	}

	void OnTriggerEnter(Collider collider)
	{	
		if (collider.tag == "Player")
			return;
		
		Debug.Log ("hoge");
		try {gameObject.GetComponent<LinearMovement> ().Speed = 0;}
		catch {
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}

		gameObject.transform.position = Target;

	}
}
