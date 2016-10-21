using UnityEngine;
using System.Collections;

public class BossMoveManager : MonoBehaviour {

	public GameObject player;

	public GameObject boss;
	public GameObject leftFoot;
	public GameObject rightFoot;
	public GameObject bossMuzzle;
	public GameObject bossBarret;

	private bool bossShot = false;
	public static bool bossAttacked = false;

	private int BossAttackedCount = 0;

	private Vector3 playerV;
	private Vector3 leftFootV;
	private Vector3 rightFootV;

	private float leftDistance;
	private float rightDistance;

	private float difDistance;

	private Animator bossAnim;

	// Use this for initialization
	void Start () {
		bossAnim = boss.GetComponent<Animator> ();

		playerV = player.transform.position;
		leftFootV = leftFoot.transform.position;
		rightFootV = rightFoot.transform.position;

		leftDistance = Vector3.Distance (playerV, leftFootV);
		rightDistance = Vector3.Distance (playerV, rightFootV);

		difDistance = leftDistance - rightDistance;


	}
	
	// Update is called once per frame
	void Update () {

		//ボスの動き

		//右回転
		if (difDistance > 15f) {
			bossAnim.SetBool ("MoveFoward", false);
			bossAnim.SetBool ("leftRotate", false);

			bossAnim.SetBool ("rightRotate", true);
		}

		//直進
		else if (difDistance > -15f) {
			bossAnim.SetBool ("leftRotate", false);
			bossAnim.SetBool ("rightRotate", false);

			bossAnim.SetBool ("MoveForward", true);
		}

		//左回転
		else if(difDistance <-15f){
			bossAnim.SetBool ("rightRotate", false);
			bossAnim.SetBool ("MoveForward", false);

			bossAnim.SetBool ("leftRotate", true);
	}

	//ボスの砲撃

//ボスとプレイヤーの位置関係を取得するスクリプト

		//発射のスクリプト
		if (bossShot == true) {
			Instantiate (bossBarret, bossMuzzle.transform.position, bossMuzzle.transform.rotation);
		}
			
		//ボスが被弾したとき
		if (bossAttacked == true) {
			bossAnim.SetTrigger("BossAttacked");
			BossAttackedCount++;
		}

		//ボスが倒されたとき
		if (BossAttackedCount == 3) {
			bossAnim.SetTrigger ("BossKilled");
		}
}
}
