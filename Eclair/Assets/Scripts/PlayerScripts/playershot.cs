using UnityEngine;
using System.Collections;

public class playershot : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}

	public GameObject shot;
	public GameObject muzzle;
	public GameObject ShotPause;
	public GameObject player;

	float shotInterval = 0;
	float shotIntervalMax = 1F;

	public GameObject lastShotPause = null; //TODO:慣れてきたらstaticを使う方法を取る

	// Update is called once per frame
	void Update ()
	{

		//発射間隔を設定する
		shotInterval += Time.deltaTime;

		//弾を発射する
		if (shotInterval > shotIntervalMax) {
			if (ShotPause != null) {
				if (Input.GetButton ("Fire2")) {
					
					Shot ();
					shotInterval = 0;
				
				}
			}
		}
	}

	void Shot (){
		if (lastShotPause != null) Destroy (lastShotPause);
		GameObject s = (GameObject)Instantiate (shot, muzzle.transform.position,Camera.main.transform.rotation);
		((shotprayer)s.GetComponent ("shotprayer")).playerShot = this;

		}
			
	}
