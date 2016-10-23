using UnityEngine;
using System.Collections;

public class BossMoveManager : MonoBehaviour {

	public GameObject player;

	public GameObject boss;
	public GameObject leftFoot;
	public GameObject rightFoot;
	public GameObject bossMuzzle;
	public GameObject bossBarret;
	public GameObject bossTail;

	private bool bossShot = true;
	public static bool bossAttacked = false;

	private int BossAttackedCount = 0;

	private Vector3 playerV;
	private Vector3 leftFootV;
	private Vector3 rightFootV;
	private Vector3 centerV;
	private Vector3 tailV;

	private float leftDistance;
	private float rightDistance;
	private float centerDistance;
	private float tailDistance;

	private float difDistanceLR;//left,right
	private float difDistanceCT;//center,tail

	private float shotInterval =0;
	private float shotIntervalMax = 1;

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
		centerV = boss.transform.position;
		tailV = bossTail.transform.position;

		leftDistance = Vector3.Distance (playerV, leftFootV);
		rightDistance = Vector3.Distance (playerV, rightFootV);
		difDistanceLR = leftDistance - rightDistance;

		centerDistance =Vector3.Distance (playerV, centerV);
		tailDistance = Vector3.Distance (playerV, tailV);
		difDistanceCT = centerDistance - tailDistance;

		//ボスの動き

		//右回転
		if (difDistanceLR > 2.0f) {
			Debug.Log ("right");
			bossAnim.SetBool ("MoveForward", false);
			bossAnim.SetBool ("LeftRotate", false);

			bossAnim.SetBool ("RightRotate", true);
			transform.Rotate (Vector3.up * Time.deltaTime * 20);
			transform.position += transform.forward * Time.deltaTime * 0;
			bossShot = false;
		}

		//直進

			if (difDistanceLR > -2.0f) {
				Debug.Log ("forward");
				bossAnim.SetBool ("LeftRotate", false);
				bossAnim.SetBool ("RightRotate", false);

				bossAnim.SetBool ("MoveForward", true);
				transform.position += transform.forward * Time.deltaTime;


		}

		//左回転
		else if(difDistanceLR <-2.0f){
			Debug.Log ("left");
			bossAnim.SetBool ("RightRotate", false);
			bossAnim.SetBool ("MoveForward", false);

			bossAnim.SetBool ("LeftRotate", true);
			transform.Rotate (Vector3.down * Time.deltaTime*20);
			transform.position += transform.forward * Time.deltaTime *0;
			bossShot = false;
	}



	//ボスの砲撃

//ボスとプレイヤーの位置関係を取得するスクリプト
		if (centerDistance >= 9.0f) {
			bossShot = true;
		} else {
			bossShot = false;
		}
		//発射のスクリプト
		shotInterval += Time.deltaTime;

		if (shotInterval > shotIntervalMax) {
			shotInterval = 0;
			
			if (bossShot == true) {
				Instantiate (bossBarret, bossMuzzle.transform.position, bossMuzzle.transform.rotation);
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
		if (BossAttackedCount == 3) {
			bossAnim.SetTrigger ("BossKilled");
			Debug.Log ("kill");
		}
}
}
