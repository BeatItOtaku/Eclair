﻿using UnityEngine;
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
	public float shotIntervalMin = 1F;

	GameObject lastShot = null; //TODO:慣れてきたらstaticを使う方法を取る

	// Update is called once per frame
	void Update ()
	{
		//発射間隔を設定する
		shotInterval += Time.deltaTime;
	}

    //InputManagerから呼び出す
	public void LaunchBolt(Vector3 target){

        if (shotInterval < shotIntervalMin) return;//前回のLaunchBoltからあんまり時間経ってない時は何もしない
        else shotInterval = 0;

        if (lastShot != null) Destroy(lastShot);//直前のShotを消す(ShotPauseを使わない仕組みに変わったからこういうことができる)

        Vector3 playerToTarget = target - muzzle.transform.position;
		GameObject go = (GameObject)Instantiate (shot, muzzle.transform.position, Quaternion.LookRotation(playerToTarget) * boltQuaternionOffset);
		if (usePhysics) go.GetComponent<Rigidbody>().AddForce(playerToTarget * force,ForceMode.VelocityChange);
		else go.GetComponent<LinearMovement>().Direction = playerToTarget;

		go.GetComponent<BoltScript> ().Target = target;

        lastShot = go;//直前のShotとして指定
	}
			
}
