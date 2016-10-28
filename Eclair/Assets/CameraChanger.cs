using UnityEngine;
using System.Collections;

public class CameraChanger : MonoBehaviour {

	public GameObject mainCamera;
	public static GameObject mainCamera_ = null;
	public GameObject changeCamera =null;
	public GameObject uI;

	public GameObject bossKilledCamera;

	// Use this for initialization
	void Start () {
		mainCamera_ = mainCamera;
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (BossMoveManager.BossAttackedCount == 2) {
			mainCamera_ = bossKilledCamera;
			bossKilledCamera.SetActive (true);
			uI.SetActive (false);
		}*/
		//mainCamera_.SetActive (true);
	}
}
