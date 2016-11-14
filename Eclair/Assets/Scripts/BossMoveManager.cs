using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossMoveManager : MonoBehaviour {

	//エクレア
	public GameObject player = null;
	public GameObject playerPositionY;

	//ボスの体とエフェクト
	public GameObject boss;
	public GameObject bossCenter;
	public GameObject leftFoot;
	public GameObject rightFoot;
	public GameObject bossMuzzle;
	public GameObject bossBarret;
	public GameObject muzzleFrash;
	public GameObject bossTail;
	public GameObject bossSmoke1;//エフェクト
	public GameObject bossSmoke2;//エフェクト
	public GameObject fire;//エフェクト
	public GameObject bossKilled;//爆発する

	public GameObject bossKilledCameraPosition;
	public Transform bossCamera;

	private bool bossShot;
	public static bool bossAttacked = false;

	public static int BossAttackedCount = 1;

	private Vector3 playerV;
	private Vector3 playerHeightV;
	private Vector3 leftFootV;
	private Vector3 rightFootV;
	private Vector3 centerV;
	private Vector3 tailV;

	private float leftDistance; //ボスの左足からプレイヤーまでの距離
	private float rightDistance; //ボスの右足からプレイヤーまでの距離
	private float centerDistance; //ボスの中心からプレイヤーまでの距離
	private float tailDistance; //ボスの尻尾の先からプレイヤーまでの距離

	private float difDistanceLR; //leftDistance,rightDistanceの差
	private float difDistanceCT; //centerDistance,tailDistanceの差

	private float shotInterval =0;
	private float shotIntervalMax = 0.1f;

	private float playerHeightF;

	public static float waitTime = 0;
	private bool wait = false;

	private Animator bossAnim;

	private AsyncOperation result;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		bossAnim = boss.GetComponent<Animator> ();
		bossShot = false;
		bossSmoke1.SetActive (false);
		bossSmoke2.SetActive (false);
		fire.SetActive (false);
		result = SceneManager.LoadSceneAsync ("Result", LoadSceneMode.Additive);
		result.allowSceneActivation = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (playerHeightF);
		playerV = player.transform.position;
		playerHeightV = playerPositionY.transform.position;
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

		playerHeightF = Vector3.Distance (playerV, playerHeightV);

		//ボスの動き


		//右回転
		if (difDistanceLR > 2.0f && waitTime == 0) {
			bossShot = false;
			//Debug.Log ("right");
			bossAnim.SetBool ("Rotation", true);
			bossAnim.SetBool ("Walk", false);
			transform.Rotate (Vector3.up * Time.deltaTime * 24 * BossAttackedCount);
			transform.position += transform.forward * Time.deltaTime * 0;
			waitTime = 0;
		}

		//直進

		if (difDistanceLR > -2.0f && waitTime == 0) {
			if (difDistanceCT < 0) {
				//Debug.Log ("forward");
				bossAnim.SetBool ("Walk", true);
				bossAnim.SetBool ("Rotation", false);
				//transform.position += transform.forward * Time.deltaTime *3;
				waitTime = 0;
			}

		}

		//左回転
		else if (difDistanceLR < -2.0f && waitTime == 0) {
			bossShot = false;
			//Debug.Log ("left");
			bossAnim.SetBool ("Rotation", true);
			bossAnim.SetBool ("Walk", false);
			transform.Rotate (Vector3.down * Time.deltaTime * 24 * BossAttackedCount);
			transform.position += transform.forward * Time.deltaTime * 0;
			waitTime = 0;
		}

		//エクレアが真後ろにいるとき反転してくる
		if (difDistanceCT > 0) {
			bossShot = false;
			wait = true;
		}
		if (wait == true) {
			waitTime += Time.deltaTime;
			if (waitTime > 2f/BossAttackedCount) {
				transform.Rotate (Vector3.down * Time.deltaTime * 40*BossAttackedCount);
				bossAnim.SetBool ("Rotation", true);
			}
		}
		if (difDistanceLR < -4.0f || difDistanceLR > 4.0f) {
			transform.Rotate (Vector3.down * Time.deltaTime * 0);
			waitTime = 0;
			wait = false;
		}

		if (playerHeightF >= 10.0f) {
			bossAnim.SetBool ("Rotation", false);
			bossAnim.SetBool ("Walk", true);
		}



	//ボスの砲撃
//ボスとプレイヤーの位置関係を取得するスクリプト
		if (centerDistance >= 8.0f && Mathf.Abs(difDistanceLR)<1.0f && difDistanceCT < 0) {
			bossShot = true;
		} else {
			bossShot = false;
		}
		shotInterval += Time.deltaTime;

		if (shotInterval > shotIntervalMax) {
			shotInterval = 0;			
			if (bossShot == true) {
				bossAnim.SetBool ("BossShot", true);
				Instantiate (bossBarret, bossMuzzle.transform.position, bossMuzzle.transform.rotation);
				Instantiate (muzzleFrash, bossMuzzle.transform.position, bossMuzzle.transform.rotation);
			} else {
				bossAnim.SetBool ("BossShot", false);
			}
		}
			
		//ボスが被弾したとき
		if (bossAttacked == true) {
			bossAnim.SetTrigger("BossAttacked");
			//BossAttackedCount++;
			Debug.Log ("attack");
			waitTime = 0;
			bossAttacked = false;

		}
		if (BossAttackedCount == 2)
		{
			bossSmoke1.SetActive (true);
		}
		if (BossAttackedCount == 3)
		{
			bossSmoke2.SetActive (true);
			fire.SetActive (true);
		}
		//ボスが倒されたとき
		if (BossAttackedCount >= 4)//BossAttackedCountの初期値は1、3回攻撃するとボス撃破
		{
			Debug.Log ("kill");
			waitTime += Time.deltaTime;
			bossAnim.SetTrigger ("BossKilled");
			if(waitTime >= 4.0f){
			CameraController.cursorIsLocked = false;
			result.allowSceneActivation = true;
			Instantiate (bossKilled, boss.transform.position, boss.transform.rotation);
			gameObject.SetActive (false);
			//bossKilledCameraPosition.transform.position = bossCamera.position;
			//bossKilledCameraPosition.transform.LookAt (bossCamera);
			//PlayerControl.EclairImmobile = true;
			}


		}
	}
}
