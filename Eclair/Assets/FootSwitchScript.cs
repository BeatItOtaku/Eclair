using UnityEngine;
using System.Collections;

public class FootSwitchScript : MonoBehaviour {

	public GameObject floor;

	private bool t = false;
	private bool s = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (t == true) {
			//gameObject.transform.position += new Vector3 (0, -0.01f, 0);
		}
		if (s == true) {
			//gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}

	private void OnCollisonEnter(Collision collider){
		if (collider.gameObject.tag == "Player") {
			Debug.Log ("hi");
			//t = true;
		}
		/*if (collider.gameObject.name == "FootSwitchCollider") {
			s = true;
		}*/
	}
	//void OnCollisionExit(Collision collider){
		//t = false;
	//}
}