using UnityEngine;
using System.Collections;

/// <summary>
/// 事実上のGameManager 名前つけるのしくったわ
/// </summary>
public class InputManager : MonoBehaviour {

	public GameObject player;

	public GameObject test;

	private int height,width;
	private Vector3 screenMiddle;

	const float DefaultShotDistance = 10;

	public enum PlayerStates {Idle,LockOn , Bolt, SBT, Etoile}

	private PlayerStates playerState_ = PlayerStates.Idle;
	/// <summary>
	/// (Read Only)プレーヤーの現在の状態
	/// </summary>
	/// <value>The state of the player.</value>
	public PlayerStates playerState {
		get{
			return playerState_;
		}
	}

	/// <summary>
	/// ロックオン、ボルト射出、SBT、エトワールが終了した時に呼ばれるメソッド
	/// </summary>
	public void Idle(){
		playerState_ = PlayerStates.Idle;
	}

	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;
		screenMiddle = new Vector3 (width / 2, height / 2, 0);
	}

	// Update is called once per frame
	void Update () {

		//右クリック
		if(Input.GetMouseButtonDown(1)){
			Debug.Log ("hogehoge");
			Ray ray = Camera.main.ScreenPointToRay (screenMiddle);
			RaycastHit hit;
			Vector3 hitPosition;
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("ahoaho");
				hitPosition = hit.point;
			} else {
				hitPosition = Camera.main.transform.position + (Camera.main.transform.forward * DefaultShotDistance);
			}
			player.GetComponent<PlayerShot> ().LaunchBolt (hitPosition);
		}

		//Eキーでロックオン
		//TODO: ロックオンのボタンを検討する
		if(Input.GetKeyDown(KeyCode.E)){
			if (playerState_ == PlayerStates.LockOn) {
				player.GetComponent<LockOn> ().Switch ();//ロックオン状態であれば次の対象へ
			}
			else {
				player.GetComponent<LockOn> ().startLockOn ();//ロックオン状態でなければロックオンを開始
				playerState_ = PlayerStates.LockOn;
			}
			test.transform.position = player.GetComponent<LockOn> ().getCurrentTarget ().transform.position;
		}
	}
}
