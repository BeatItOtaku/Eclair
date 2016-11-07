using UnityEngine;
using System.Collections;

public class Event2CameraChanger : MonoBehaviour {

	public GameObject mainCamera = null;
	private CameraController cc = null;

	public EventManager2 em2;
	public GameObject event2_1Angle;

	private float waitTime;
	public static bool cameraSet;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		cc = mainCamera.GetComponent<CameraController> ();

		waitTime = 0;
		cameraSet = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (em2.eventCount2 == 1) 
		{
			cameraSet = true;
			PlayerControl.EclairImmobile = true;
			CameraController.lookAt = event2_1Angle;
			waitTime += Time.deltaTime;

			if (waitTime >= 3.0f) {
				cameraSet = false;
				PlayerControl.EclairImmobile = false;
				em2.EventCount2 ();
				waitTime = 0;
	
			}
		}
	}
}
