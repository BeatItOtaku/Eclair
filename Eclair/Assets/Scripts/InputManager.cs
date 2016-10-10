using UnityEngine;
using System.Collections;

/// <summary>
/// 事実上のGameManager 名前つけるのしくったわ
/// </summary>
public class InputManager : MonoBehaviour {

	public GameObject player;
	public ThunderEffectController thunderEffect;

	public GameObject test;

	public CrossHairController crossHair;

    public CameraController camControl;

	public LockOn lockOn;

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
		player.GetComponent<LockOn> ().endLockOn ();
        crossHair.isLockOn = false;
        camControl.StopLockOn();
        PlayerControl.fly = false;
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
            //Debug.Log ("MouseLeft");
            if (playerState == PlayerStates.LockOn)//ロックオン状態の時は対象切り替え
            {
                GameObject go = player.GetComponent<LockOn>().Switch();//ロックオン状態であれば次の対象へ
                onLockOnSwitched(go);
            }
            else//ロックオン状態じゃないときはボルト射出
            {
                Ray ray = Camera.main.ScreenPointToRay(screenMiddle);
                RaycastHit hit;
                Vector3 hitPosition;
                Quaternion hitQuaternion = Quaternion.Euler(0,0,0);
                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log ("ahoaho");
                    hitPosition = hit.point;
                    hitQuaternion = Quaternion.LookRotation(hit.normal);
                }
                else
                {
                    hitPosition = Camera.main.transform.position + (Camera.main.transform.forward * DefaultShotDistance);
                }
                player.GetComponent<PlayerShot>().LaunchBolt(hitPosition, hitQuaternion);
            }
		}

		//Eキーでロックオン
		//TODO: ロックオンのボタンを検討する
		if(Input.GetKeyDown(KeyCode.E)){
			GameObject go;
			if (playerState_ == PlayerStates.Idle) {
				go = player.GetComponent<LockOn> ().startLockOn ();//アイドル状態であればロックオンを開始
                if (go != null)
                {
                    playerState_ = PlayerStates.LockOn;
                    onLockOnSwitched(go);
                }
			}
		}
        else if (Input.GetKeyUp(KeyCode.E))//Eキー離したらロックオンやめる
        {
            player.GetComponent<LockOn>().endLockOn();
            Idle();
        }

		//左クリック
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Fire1Pressed");
			GameObject satou = null;
			if(playerState_ == PlayerStates.LockOn) satou = player.GetComponent<LockOn> ().getCurrentTarget ();//satouとはロックオンで取得したボルト
			if (satou != null) {
				thunderEffect.StartEffect (player.transform.position, satou.transform.position);
			}
		} else if (Input.GetButtonUp ("Fire1")) {
			thunderEffect.StopEffect ();
		}

		//エトワールボタン
		if (Input.GetButtonDown ("Etoile")) {
			if (playerState_ == PlayerStates.LockOn){
				player.GetComponent<Etoile> ().startEtoile (lockOn.getCurrentTarget());
				playerState_ = PlayerStates.Etoile;
			}
		}
	}

    void onLockOnSwitched(GameObject target)
    {
		if(target != null){
        crossHair.target = target.transform.position;//player.GetComponent<LockOn> ().getCurrentTarget ().transform.position;
        crossHair.isLockOn = true;
        camControl.StartLockOn(target);
    }
	}

	static float getAngleWithSign(Vector3 v1, Vector3 v2){
		float angle = Vector3.Angle (v1, v2);
		int sign = Vector3.Cross(v1, v2).z < 0 ? -1 : 1;
		return angle * sign;
	}

    public string getDebugString()
    {
        string st = "";

        st += "PlayerState : " + playerState_.ToString() + "\n";
        st += "CameraY : " + camControl.cameraY + "\n";
        st += "CameraAngle : " + camControl.cameraAngle + "\n";


        return st;
    }
}
