using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public GameObject player;

	private int height,width;
	private Vector3 screenMiddle;

	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;
		screenMiddle = new Vector3 (height / 2, width / 2, 0);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1)){
			Debug.Log ("hogehoge");
			Ray ray = Camera.main.ScreenPointToRay (screenMiddle);

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log ("ahoaho");
				Vector3 objectHit = hit.point;
				player.GetComponent<PlayerShot> ().LaunchBolt (objectHit);
			}


		}
	}
}
