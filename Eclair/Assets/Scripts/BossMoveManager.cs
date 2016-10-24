﻿using UnityEngine;
using System.Collections;

public class BossMoveManager : MonoBehaviour {

	public GameObject player;

	public GameObject boss;
	public GameObject bossCenter;
	public GameObject leftFoot;
	public GameObject rightFoot;
	public GameObject bossMuzzle;
	public GameObject bossBarret;
	public GameObject bossTail;

	private bool bossShot = true;
	public static bool bossAttacked = false;

	private int BossAttackedCount = 1;

	private Vector3 playerV;
	private Vector3 leftFootV;
	private Vector3 rightFootV;
	private Vector3 centerV;
	private Vector3 tailV;

	private float leftDistance;
	private float rightDistance;
	private float centerDistance;
	private float tailDistance;

	private float difDistanceLR;//leftDistance,rightDistanceの差
	private float difDistanceCT;//centerDistance,tailDistanceの差

	private float shotInterval =0;
	private float shotIntervalMax = 1;

	private float waitTime = 0;
	private bool wait = false;

	private Animator bossAnim;

	// Use this for initialization
	void Start () {
		bossAnim = boss.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerV = player.transform.position;
		leftFootV = leftFoot.transform.position;
		rightFootV = rightFoot.transform.position;
		centerV = bossCenter.transform.position;
		tailV = bossTail.transform.position;

		leftDistance = Vector3.Distance (playerV, leftFootV);
		rightDistance = Vector3.Distance (playerV, rightFootV);
		difDistanceLR = leftDistance - rightDistance;

		centerDistance = Vector3.Distance (playerV, centerV);
		tailDistance = Vector3.Distance (playerV, tailV);
		difDistanceCT = centerDistance - tailDistance;

		//ボスの動き

		//右回転
		if (difDistanceLR > 2.0f && waitTime == 0) {
			//Debug.Log ("right");
			bossAnim.SetBool ("MoveForward", false);
			bossAnim.SetBool ("LeftRotate", false);

			bossAnim.SetBool ("RightRotate", true);
			transform.Rotate (Vector3.up * Time.deltaTime * 10 * BossAttackedCount);
			transform.position += transform.forward * Time.deltaTime * 0;
			bossShot = false;
			waitTime = 0;
		}

		//直進

		if (difDistanceLR > -2.0f && waitTime == 0) {
			if (difDistanceCT < 0) {
				//Debug.Log ("forward");
				bossAnim.SetBool ("LeftRotate", false);
				bossAnim.SetBool ("RightRotate", false);

				bossAnim.SetBool ("MoveForward", true);
				transform.position += transform.forward * Time.deltaTime * BossAttackedCount;
				waitTime = 0;
			}

		}

		//左回転
		else if (difDistanceLR < -2.0f && waitTime == 0) {
			//Debug.Log ("left");
			bossAnim.SetBool ("RightRotate", false);
			bossAnim.SetBool ("MoveForward", false);

			bossAnim.SetBool ("LeftRotate", true);
			transform.Rotate (Vector3.down * Time.deltaTime * 10 * BossAttackedCount);
			transform.position += transform.forward * Time.deltaTime * 0;
			bossShot = false;
			waitTime = 0;
		}

		//エクレアが真後ろにいるとき反転してくる
		if (difDistanceCT > 0) {
			wait = true;
		}
		if (wait == true) {
			waitTime += Time.deltaTime;
			if (waitTime > 2f) {
				transform.Rotate (Vector3.down * Time.deltaTime * 60);
			}
		}
		if (difDistanceLR < -4.0f || difDistanceLR > 4.0f) {
			transform.Rotate (Vector3.down * Time.deltaTime * 0);
			waitTime = 0;
			wait = false;
		}



	//ボスの砲撃
//ボスとプレイヤーの位置関係を取得するスクリプト
		if (centerDistance >= 9.0f) {
			bossShot = true;
		} else {
			bossShot = false;
		}
		shotInterval += Time.deltaTime;

		if (shotInterval > shotIntervalMax) {
			shotInterval = 0;			
			if (bossShot == true) {
				//Instantiate (bossBarret, bossMuzzle.transform.position, bossMuzzle.transform.rotation);
			}
		}
			
		//ボスが被弾したとき
		if (bossAttacked == true) {
			bossAnim.SetTrigger("BossAttacked");
			BossAttackedCount++;
			Debug.Log ("attack");
			bossAttacked = false;
		}

		//ボスが倒されたとき
		if (BossAttackedCount == 4)//BossAttackedCountの初期値は1、3回攻撃するとボス撃破
		{
			bossAnim.SetTrigger ("BossKilled");
			Debug.Log ("kill");
		}
}
}
