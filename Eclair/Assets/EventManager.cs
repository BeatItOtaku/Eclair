using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	/*EventManagerはチュートリアルマップのイベントを管理。
    eventCount == 0  初期値（括弧内はトリガーとなる行動）
    1 ロックオンのチュートリアル（道を通る）
    2 カメラが銃を写す（ロックオンキーを押す）
    3 SBTのチュートリアル（銃を写したカメラがプレイヤーを写すように戻る）
    4 ETOのチュートリアル(敵を倒す）
    5 ETO用のボルトが現れる（ETOで壁を破壊する）
    6 ボルトを撃つチュートリアル（銃を取得する）
    7 ボルトを壁にさして電撃で壊す（6と同じ）
    8 敵を倒す（壁を破壊する）
    9 工場内マップに移動する（道を通る）



*/
	public GameObject AnimationQueue = null;
	//public AnimationQueue_Tutorial queueMove;

	public GameObject event2_bolt;
	public GameObject event3_zako;
	public GameObject event3_bolt;
	public GameObject event4_bolt1;
	public GameObject event4_bolt2;
	public GameObject event5_bolt;


	public GameObject event6_gun;
	public GameObject event6_EclairGun = null;
	public GameObject event7_wall;
	public GameObject event8_zako;
	public GameObject event9_way;

	public static int eventCount;

	private bool gunGet;


	// Use this for initialization
	void Start () {
		AnimationQueue = GameObject.Find ("Canvas");
		//queueMove.Queue ();
		eventCount = 0;
		gunGet = false;

		event3_zako.SetActive (false);
		event3_bolt.SetActive (false);

		event5_bolt.SetActive (false);

		event6_EclairGun = GameObject.Find ("Gun");
		event6_EclairGun.SetActive (false);

		event8_zako.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (eventCount);
	}


	public void EventCount(){
		eventCount++;
		if (eventCount == 1) 
		{//ロックオンのチュートリアルが表示される 
			GameObject.Find ("Tutorial_LockOn").GetComponent<AnimationQueue_Tutorial> ().Queue ();
		}
		if (eventCount == 2) 
		{ //ロックオンボタンを押した状態、銃にカメラが向く（予定）
			GameObject.Find ("Tutorial_LockOn").GetComponent<AnimationQueue_Tutorial> ().Queue ();
		}
		if (eventCount == 3) 
		{ //SBTのチュートリアルが表示される
			GameObject.Find ("Tutorial_Thunder").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			event2_bolt.SetActive (false);

			event3_zako.SetActive (true);
			event3_bolt.SetActive (true);
		}
		if (eventCount == 4)
		{ //ETOのチュートリアルが表示される
			GameObject.Find ("Tutorial_Thunder").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			GameObject.Find ("Tutorial_Etoile").GetComponent<AnimationQueue_Tutorial> ().Queue ();

			if (event4_bolt1 != null) { 
				event4_bolt1.tag = "Bolt";
			}
			if (event4_bolt2 != null) {
				event4_bolt2.tag = "Bolt";				
			}
		}
		if (eventCount == 5) 
		{//ETOで移動用のボルトが現れる
			event5_bolt.SetActive (true);
		}
		if (eventCount == 6) 
		{ //ボルト射出のチュートリアルが表示される
			GameObject.Find ("Tutorial_Etoile").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			GameObject.Find ("Tutorial_Bolt").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			event5_bolt.SetActive (false);
			event6_gun.SetActive (false);
			event6_EclairGun.SetActive (true);
			gunGet = true;
		}
		/*if (eventCount == 7) { //ボルトをさして、電撃で破壊する壁（予定）

		}*/
		if (eventCount == 7/*8*/)
		{//雑魚との戦闘
			event8_zako.SetActive (true);
		}
		if (eventCount ==8 /*9*/) 
		{//工場マップへ移動
		}
	}

}
