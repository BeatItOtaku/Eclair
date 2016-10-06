using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public GameObject player;
	public ThunderEffectController thunderEffect;

	private int height,width;
	private Vector3 screenMiddle;

	const float DefaultShotDistance = 10;

	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;
		screenMiddle = new Vector3 (width / 2, height / 2, 0);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1)){
			Debug.Log ("hogehoge");
			Ray ray = Camera.main.ScreenPointToRay (screenMiddle);
			RaycastHit hit;
			Vector3 hitPosition;
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("ahoaho");
				hitPosition = hit.point;
			} else {
				hitPosition = Camera.main.transform.position + (Camera.main.transform.forward * DefaultShotDistance);
			}
			player.GetComponent<PlayerShot> ().LaunchBolt (hitPosition);
		}

		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Fire1Pressed");
			thunderEffect.StartEffect (player.transform.position, new Vector3 (10, 4, 10));
		} else if (Input.GetButtonUp ("Fire1")) {
			thunderEffect.StopEffect ();
		}
	}
}
