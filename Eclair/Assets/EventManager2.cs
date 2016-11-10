using UnityEngine;
using System.Collections;

public class EventManager2 : MonoBehaviour {

	/// <summary>
	/// zakomapのイベント管理。
	/// eventCount2 == 0が初期値。
	/// 1は通路を通り、カメラがボス扉を映す。
	/// 2は雑魚出現とSBTスイッチ二つの謎解き。
	/// 3はSBTスイッチ3つの謎解き。
	/// 4はボススイッチを押せる状態になる。
	/// 5はボススイッチを押してる最中、カメラが次の進路を映す。
	/// 6はボススイッチを押し終わったあと
	/// 7はETOステージに突入、雑魚登場
	/// 8はボススイッチ二つ目を押してる最中、カメラが次の進路を映す。
	/// 9はボス扉に突入
	/// </summary>

	public static int bossSwitchCount;
	public int eventCount2;

	public GameObject event1_camera;
	public GameObject event2_zako;
	public GameObject event7_zako;


	// Use this for initialization
	void Start () {
		bossSwitchCount = 0;
		eventCount2 = 0;

		event2_zako.SetActive (false);
		event7_zako.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("eventCount2");
	
	}

	public void EventCount2(){
		eventCount2++;

		switch (eventCount2) {

		case 0:
			break;

		case 1:
			//カメラがボス扉を映す
			break;
		case 2:
			event2_zako.SetActive (true);

			break;

		case 3:

			break;

		case 4:
			break;

	    case 5:
			
			break;

		case 6:

			break;

		case 7:
			event7_zako.SetActive (true);
			break;

		case 8:
			break;

		case 9:
			break;
		}
	}

	public void BossSwitch(){
		bossSwitchCount++;
		switch (bossSwitchCount) {

		case 0:
			break;

		case 1:
			//ボスの扉のランプが一つ点灯
			break;

		case 2:
			//ボスの扉のランプがもう一つ点灯
			break;
		}
	}
		
}
