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
		Destroy (gameObject, 3);
	//弾を前進させる
		transform.position += transform.forward *Time.deltaTime * 70 ;
	}

	public void LaunchBolt(Vector3 target){
		Vector3 playerToTarget = target - gameObject.transform.position;
		GameObject go = (GameObject)Instantiate (shot, muzzle.transform.position, Quaternion.LookRotation(playerToTarget));
		go.GetComponent<LinearMovement> ().Direction = playerToTarget;
	}

	private void OnCollisionEnter(Collision collider)

	{		
			playerShot.lastShotPause = (GameObject)Instantiate (ShotPause,transform.position,transform.rotation);
			Instantiate (lightning, transform.position, transform.rotation);
			Destroy (gameObject);
	

}
}
