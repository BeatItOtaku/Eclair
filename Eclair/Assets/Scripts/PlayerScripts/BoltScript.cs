using UnityEngine;
using System.Collections;

public class shotprayer : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}
	public GameObject ShotPause;
	private GameObject shot;
	public playershot playerShot;
	public GameObject lightning;


	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 3);
	//弾を前進させる
		transform.position += transform.forward *Time.deltaTime*70 ;
	}

	private void OnCollisionEnter(Collision collider)

	{		
			playerShot.lastShotPause = (GameObject)Instantiate (ShotPause,transform.position,transform.rotation);
			Instantiate (lightning, transform.position, transform.rotation);
			Destroy (gameObject);
	

}
}
