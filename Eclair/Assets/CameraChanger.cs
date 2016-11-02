using UnityEngine;
using System.Collections;

public class CameraChanger : MonoBehaviour {

	public GameObject player;
	public GameObject mainCamera;
	public static GameObject mainCamera_ = null;

	public GameObject event2StartCameraPosition = null;
	public GameObject event2EndPosition = null;

	public GameObject uI;

	public GameObject em = null;

	public GameObject bossKilledCamera;

	private float cameraWaitTime;

	// Use this for initialization
	void Start () {
		em = GameObject.Find ("EventManager");
		event2StartCameraPosition = GameObject.Find ("Event2_StartPosition");
		event2EndPosition = GameObject.Find ("EndPosition");
		mainCamera_ = mainCamera;
		cameraWaitTime = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (BossMoveManager.BossAttackedCount == 2) {
			mainCamera_ = bossKilledCamera;
			bossKilledCamera.SetActive (true);
			uI.SetActive (false);
		}
		if (EventManager.eventCount == 2) {
			PlayerControl.EclairImmobile = true;
			mainCamera_ = event2StartCameraPosition;
			cameraWaitTime += Time.deltaTime;
			if (cameraWaitTime >= 10.0f) {
				PlayerControl.EclairImmobile = false;
				mainCamera_ = player;
				em.GetComponent<EventManager>().EventCount ();
			}
		}
	}
}
