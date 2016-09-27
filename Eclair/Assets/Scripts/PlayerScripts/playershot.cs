using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {



	// Use this for initialization
	void Start () {
		boltQuaternionOffset = Quaternion.Euler (boltRotationOffset);
	}

	public GameObject shot;
	public GameObject muzzle;
	public GameObject ShotPause;
	public GameObject player;
	public Vector3 boltRotationOffset;

	public bool usePhysics = false;
	public float force = 10;

	private Quaternion boltQuaternionOffset;

	float shotInterval = 0;
	float shotIntervalMax = 1F;

	public GameObject lastShotPause = null; //TODO:慣れてきたらstaticを使う方法を取る

	// Update is called once per frame
	void Update ()
	{

		//発射間隔を設定する
		shotInterval += Time.deltaTime;

		/*//弾を発射する
		if (shotInterval > shotIntervalMax) {
			if (ShotPause != null) {
				if (Input.GetButton ("Fire2")) {
					
					Shot ();
					shotInterval = 0;
				
				}
			}
		}*/
	}

	/*void Shot (){
		if (lastShotPause != null) Destroy (lastShotPause);
		GameObject s = (GameObject)Instantiate (shot, muzzle.transform.position,Camera.main.transform.rotation);
		((BoltScript)s.GetComponent ("shotprayer")).playerShot = this;

	}*/


	public void LaunchBolt(Vector3 target){

		if (shotInterval < shotIntervalMax) return;//前回のLaunchBoltからあんまり時間経ってない時は何もしない

		Vector3 playerToTarget = target - muzzle.transform.position;
		//Debug.Log (target);
		//Debug.Log (muzzle.transform.position);
		GameObject go = (GameObject)Instantiate (shot, muzzle.transform.position, Quaternion.LookRotation(playerToTarget) * boltQuaternionOffset);
        Instantiate(player, target, new Quaternion(0,0,0,0));
		if (usePhysics) go.GetComponent<Rigidbody>().AddForce(playerToTarget,ForceMode.VelocityChange);
		else go.GetComponent<LinearMovement>().Direction = playerToTarget * force;
	}
			
}
