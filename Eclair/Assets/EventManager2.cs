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

	public  int bossSwitchCount;
	public int eventCount2;

	public GameObject event1_camera;
	public GameObject event2_zako;
	public GameObject event2_yajirushi;
	public GameObject event3_yajirushi;
	public GameObject event4_bikkuri;
	public GameObject event6_yajirushi;
	public GameObject event7_bikkuri;
	public GameObject event7_zako;
	public GameObject event9_yajirushi;

	public BossGate bg;


	// Use this for initialization
	void Start () {
		bossSwitchCount = 0;
		eventCount2 = 4;

		event2_zako.SetActive (false);
		event2_yajirushi.SetActive (false);
		event3_yajirushi.SetActive (false);
		event4_bikkuri.SetActive (false);
		event6_yajirushi.SetActive (false);
		event7_bikkuri.SetActive (false);
		event7_zako.SetActive (false);
		event9_yajirushi.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (eventCount2);
		Debug.Log (bossSwitchCount);
	
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
			event2_yajirushi.SetActive (true);
			event2_zako.SetActive (true);

			break;

		case 3:
			event2_yajirushi.SetActive (false);
			event3_yajirushi.SetActive (true);

			break;

		case 4:
			event3_yajirushi.SetActive (false);
			event4_bikkuri.SetActive (true);
			break;

	    case 5:
			event4_bikkuri.SetActive (false);
			
			break;

		case 6:
			event6_yajirushi.SetActive (true);

			break;

		case 7:
			event6_yajirushi.SetActive (false);
			event7_bikkuri.SetActive (true);
			event7_zako.SetActive (true);
			break;

		case 8:
			event7_bikkuri.SetActive (false);
			break;

		case 9:
			event9_yajirushi.SetActive (true);
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
			bg.DoorOpen();
			break;
		}
	}
		
}
