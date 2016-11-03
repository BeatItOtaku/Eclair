using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

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
		if (eventCount == 1)//ロックオンのチュートリアルが表示される 
		{
			GameObject.Find ("Tutorial_LockOn").GetComponent<AnimationQueue_Tutorial> ().Queue ();
		}
		if (eventCount == 2) {
			GameObject.Find ("Tutorial_LockOn").GetComponent<AnimationQueue_Tutorial> ().Queue ();
		}
		if (eventCount == 3) //SBTのチュートリアルが表示される
		{
			GameObject.Find ("Tutorial_Thunder").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			event2_bolt.SetActive (false);

			event3_zako.SetActive (true);
			event3_bolt.SetActive (true);
		}
		if (eventCount == 4) //ETOのチュートリアルが表示される
		{
			GameObject.Find ("Tutorial_Thunder").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			GameObject.Find ("Tutorial_Etoile").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			if (event4_bolt1 != null) { 
				event4_bolt1.tag = "Bolt";
			} else {
				EventCount ();
			}
			if(event4_bolt2 != null){
				event4_bolt2.tag = "Bolt";				
			}
		}
		if (eventCount == 5) {
			event5_bolt.SetActive (true);
		}
		if (eventCount == 6) //ボルト射出のチュートリアルが表示される
		{
			GameObject.Find ("Tutorial_Etoile").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			GameObject.Find ("Tutorial_Bolt").GetComponent<AnimationQueue_Tutorial> ().Queue ();
			event5_bolt.SetActive(false);
			event6_gun.SetActive (false);
			event6_EclairGun.SetActive (true);
			gunGet = true;
			if (gunGet == true) {
				eventCount +=2;
			}
		}
		if (eventCount == 7) {

		}
		if (eventCount == 8) {
			event8_zako.SetActive (true);
		}
	}

}
