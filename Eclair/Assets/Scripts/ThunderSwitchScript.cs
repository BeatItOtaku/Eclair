using UnityEngine;
using System.Collections;

public class ThunderSwitchScript : MonoBehaviour {

	private Animator animator;

	public GameObject player;
	public float time;

	GameObject satou = null;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetBool ("ThunderSwitch", false);
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			if (satou != null) {
				satou = player.GetComponent<LockOn> ().getCurrentTarget ();//satouとはロックオンで取得したボルト

				Vector3 thunder = satou.transform.position - player.transform.position;
				Vector3 objectVector = transform.position - player.transform.position;
				float angle = Vector3.Angle (thunder, objectVector);
				time += Time.deltaTime;

					if (angle < 30) {
						if (time < 3) {
							animator.SetBool ("ThunderSwitch", true);
							Debug.Log ("hi");
						}
					}

				if (time >= 3) {
					Debug.Log ("eiei");
					animator.SetBool ("ThunderSwitch", false);
			
				}
			}
		}
	}
}
