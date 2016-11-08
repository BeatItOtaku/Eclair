using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	/*EventManagerはチュートリアルマップのイベントを管理。
    eventCount == 0  初期値（括弧内はトリガーとなる行動）
    1 ロックオンのチュートリアル（道を通る）
    2 カメラが銃を写す（ロックオンキーを押す）
    3 SBTのチュートリアル（銃を写したカメラがプレイヤーを写すように戻る）
    4 ETOのチュートリアル(敵を倒す）
    5 SBTスイッチのチュートリアル（ETOで壁を壊す）
    6 金網のチュートリアル（SBTスイッチで道を開ける）
    7 銃をゲット
    8 敵を倒す（壁を破壊する）
    9 工場内マップに移動する（道を通る）



*/
	//public AnimationQueue_Tutorial queueMove;

	public GameObject event2_bolt;
	public GameObject event2_sita;
	public GameObject event3_zako;
	public GameObject event3_bolt;
	public GameObject event4_bolt1;
	public GameObject event4_bolt2;
	public GameObject event5_bolt;
	public GameObject event5_ue;

	public GameObject event6_gun;
	public GameObject event6_EclairGun = null;
	public GameObject event6_yajirushi;
	public GameObject event7_zako;
	public GameObject event9_way;

	public GameObject HPGauge = null;

	public static int eventCount;

	private GameObject tutorialMove = null;


	// Use this for initialization
	void Start () {
		//AnimationQueue = GameObject.Find ("Canvas");
		//queueMove.Queue ();
		eventCount = 0;


		event2_sita.SetActive (false);
		event3_zako.SetActive (false);
		event3_bolt.SetActive (false);

		event5_bolt.SetActive (false);
		event5_ue.SetActive (false);

		event6_EclairGun = GameObject.Find ("Gun");
		event6_EclairGun.SetActive (false);
		event6_yajirushi.SetActive (false);

		event7_zako.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (eventCount);
		if (tutorialMove == null) {
			tutorialMove = GameObject.Find ("Tutorial_Move");
			if (tutorialMove != null) {
				tutorialMove.GetComponent<AnimationQueue_Tutorial> ().Queue ();
			}
		}
		if (HPGauge == null)
			HPGauge = GameObject.Find ("HPGauge");
	}

	public void EventCount(){
		eventCount++;
		switch (eventCount) {
		case 0:
			break;
		case 1:
			//ロックオンのチュートリアルが表示される 
			event2_sita.SetActive (true);
			GameObject.Find ("Tutorial_Move").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			GameObject.Find ("Tutorial_LockOn").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			break;
		case 2:
			GameObject.Find ("Tutorial_LockOn").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			break;
		case 3:
			//SBTのチュートリアルが表示される
			GameObject.Find ("Hint_Enemy").GetComponent<AnimationQueue_InAndOut> ().Queue ();
			GameObject.Find ("Tutorial_Thunder").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			event2_bolt.SetActive (false);

			event3_zako.SetActive (true);
			event3_bolt.SetActive (true);
			break;
		case 4:
			//ETOのチュートリアルが表示される
			GameObject.Find ("Hint_Enemy").GetComponent<AnimationQueue_InAndOut> ().Queue ();
			GameObject.Find ("Tutorial_Thunder").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			GameObject.Find ("Tutorial_Etoile").GetComponent<AnimationQueue_Tutorial> ().Queue ();

			event3_bolt.SetActive (false);
			event4_bolt1.tag = "Bolt";				
			event4_bolt2.tag = "Bolt";	
			break;
		case 5:
			//ETOで移動用のボルトが現れる
			GameObject.Find ("Hint_Gun").GetComponent<AnimationQueue_InAndOut> ().Queue ();
			event5_bolt.SetActive (true);
			event5_ue.SetActive (true);
			break;

		case 6:
			//ボルト射出のチュートリアルが表示される
			GameObject.Find ("Hint_Gun").GetComponent<AnimationQueue_InAndOut> ().Queue ();
			//GameObject.Find("Hint_Bolt").GetComponent<AnimationQueue_InAndOut>().Queue();
			GameObject.Find ("Tutorial_Etoile").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			GameObject.Find ("Tutorial_Bolt").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			event2_sita.SetActive (false);
			event5_bolt.SetActive (false);
			event5_ue.SetActive (false);
			event6_gun.SetActive (false);
			event6_EclairGun.SetActive (true);
			event6_yajirushi.SetActive (true);
			break;

		case 7:
			//雑魚との戦闘
			//GameObject.Find("Hint_Bolt").GetComponent<AnimationQueue_InAndOut>().Queue();
			GameObject.Find ("Hint_Enter").GetComponent<AnimationQueue_InAndOut> ().Queue ();
			event6_yajirushi.SetActive (false);
			event7_zako.SetActive (true);
			break;
		case 8:
			//工場へ突入
			StartCoroutine (hideTutorialUIs());
			break;
		}
	}

	private IEnumerator hideTutorialUIs(){
		string[] objNames = { "Hint_Enter","Tutorial_Bolt", "Tutorial_LockOn", "Tutorial_Thunder", "Tutorial_Etoile", "Tutorial_Bolt" };
		foreach(string obj in objNames){
			InvokeQueue (obj);
			yield return new WaitForSecondsRealtime (0.1f);
		}
		HPGauge.SetActive (true);
	}

	private void InvokeQueue(string obj){
		GameObject.Find (obj).GetComponent<AnimationQueueBase> ().Queue ();
	}

/*	public void EventCount(){
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
			GameObject.Find("Hint_Enemy").GetComponent<AnimationQueue_InAndOut>().Queue();
			GameObject.Find ("Tutorial_Thunder").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			event2_bolt.SetActive (false);

			event3_zako.SetActive (true);
			event3_bolt.SetActive (true);
		}
		if (eventCount == 4)
		{ //ETOのチュートリアルが表示される
			GameObject.Find("Hint_Enemy").GetComponent<AnimationQueue_InAndOut>().Queue();
			GameObject.Find ("Tutorial_Thunder").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			GameObject.Find ("Tutorial_Etoile").GetComponent<AnimationQueue_Tutorial> ().Queue ();

			event3_bolt.tag = "Untagged";
				event4_bolt1.tag = "Bolt";				
				event4_bolt2.tag = "Bolt";				

		}
		if (eventCount == 5) 
		{//ETOで移動用のボルトが現れる
			GameObject.Find("Hint_Gun").GetComponent<AnimationQueue_InAndOut>().Queue();
			event5_bolt.SetActive (true);
		}
		if (eventCount == 6) 
		{ //ボルト射出のチュートリアルが表示される
			GameObject.Find("Hint_Gun").GetComponent<AnimationQueue_InAndOut>().Queue();
			GameObject.Find ("Tutorial_Etoile").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			GameObject.Find ("Tutorial_Bolt").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			event5_bolt.SetActive (false);
			event6_gun.SetActive (false);
			event6_EclairGun.SetActive (true);
			gunGet = true;
		}
		/*if (eventCount == 7) { //ボルトをさして、電撃で破壊する壁（予定）
GameObject.Find("Hint_Bolt").GetComponent<AnimationQueue_InAndOut>().Queue();

		}
		if (eventCount == 7/*8)
		{//雑魚との戦闘
			//GameObject.Find("Hint_Bolt").GetComponent<AnimationQueue_InAndOut>().Queue();
			event8_zako.SetActive (true);
			if (event8_zako == null) {
				EventCount ();
			}
		}
		if (eventCount ==8 /*9) 
		{//工場マップへ移動
			GameObject.Find("Hint_Enter").GetComponent<AnimationQueue_InAndOut>().Queue();
		}
	}*/

}
