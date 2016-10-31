using UnityEngine;
using System.Collections;

public class CameraChanger : MonoBehaviour {

	public GameObject player;
	public GameObject mainCamera;
	public static GameObject mainCamera_ = null;

	public GameObject event2StartCameraPosition;
	public Transform event2EndPosition;

	public GameObject uI;

	public EventManager em;

	public GameObject bossKilledCamera;

	private float cameraWaitTime;

	// Use this for initialization
	void Start () {
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
			if (cameraWaitTime >= 4.0f) {
				PlayerControl.EclairImmobile = false;
				em.EventCount ();
			}
		}
	}
}
