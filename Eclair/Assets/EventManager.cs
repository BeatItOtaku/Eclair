using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public GameObject event2_bolt;
	public GameObject event3_zako;
	public GameObject event3_bolt;
	public GameObject event4_bolt;
	public GameObject event5_bolt1;


	public GameObject event6_gun;
	public GameObject event6_EclairGun;
	public GameObject event7_wall;
	public GameObject event8_zako;
	public GameObject event9_way;

	public static int eventCount;


	// Use this for initialization
	void Start () {
		eventCount = 1;

		event2_bolt.SetActive (false);
		event3_zako.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (eventCount == 2) {
			event2_bolt.SetActive (true);		
		}
		if (eventCount == 3) {
			event2_bolt.SetActive (false);

			event3_zako.SetActive (true);
			event3_bolt.SetActive (true);
		}
		if (eventCount == 4) {
			event3_bolt.SetActive (false);
			event4_bolt.SetActive (true);
		}
		if (eventCount == 5) {
			event4_bolt.SetActive (false);
			event5_bolt1.SetActive (true);
		}
		if (eventCount == 6) {
			//event5_boltX.SetActive(false);
			event6_gun.SetActive (false);
			event6_EclairGun.SetActive (true);
		}
		if (eventCount == 7) {
		}
		if (eventCount == 8) {
			event8_zako.SetActive (true);
		}
	}


	public void EventCount(){
		eventCount++;
	}

}
