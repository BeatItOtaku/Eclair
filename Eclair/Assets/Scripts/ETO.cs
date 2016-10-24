using UnityEngine;
using System.Collections;

public class ETO : MonoBehaviour {

	public GameObject target = null;
	public GameObject player;
	public GameObject lightning;
	public InputManager im;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.etoile == true) {
			//target = player.GetComponent<LockOn> ().getCurrentTarget ();
			if (target != null) {
				transform.LookAt (target.transform);
				transform.position += transform.forward * Time.deltaTime * 30;
			}
		}
	}
	private void OnCollisionEnter (Collision collider)
	{
		//Debug.Log ("ETO.OnCollisionEnter");

		//ボルトにぶつかったとき・・・電気のエフェクトを出す
		if (collider.gameObject.tag == "Bolt") {	
			//Debug.Log ("CollideToBolt");
			player.transform.position = target.transform.position;
			Instantiate (lightning, transform.position, transform.rotation);
			//Destroy (target);
			InputManager.etoile = false;
			im.Idle ();
			gameObject.SetActive (false);

			if (target.layer == 7) {
				//layer7は"Bolt"
				Destroy (target);
			}
		}

		//ボルト以外にぶつかったとき・・・電気のエフェクトは出ない
		if(collider.gameObject.tag == "EclairKeepOut"||collider.gameObject.tag == "Boss"){
			//Debug.Log ("CollideToKeepOut");
			player.transform.position = InputManager.eto_.transform.position;
			InputManager.etoile = false;
			im.Idle ();
			gameObject.SetActive (false);
		}
	}
}
