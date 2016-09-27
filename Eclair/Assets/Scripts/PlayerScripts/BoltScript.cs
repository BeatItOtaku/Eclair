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


	// Update is called once per frame
	void Update () {
		//Destroy (gameObject, 3);
		//弾を前進させる
		//transform.position += transform.forward *Time.deltaTime * 70 ;
		Debug.Log(gameObject.transform.position);
	}

	void OnTriggerEnter(Collider collider)
	{		
		Debug.Log ("hoge");
		gameObject.GetComponent<LinearMovement> ().Speed = 0;
		gameObject.GetComponent<Rigidbody> ().isKinematic = true;

	}
}
