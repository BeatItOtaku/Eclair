using UnityEngine;
using System.Collections;

public class Etoile : MonoBehaviour {

	public GameObject lightning;
	public GameObject player;
	GameObject target = null;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Etoile")) {
			//ターゲットを取得する
			target = GameObject.FindWithTag ("NoMoveBolt");
		}
			if (target != null) {
				//ターゲットの方向を向く
				transform.LookAt (target.transform);
				transform.position += transform.forward * Time.deltaTime * 50;
			//player.GetComponent<Rigidbody> ().useGravity = false;
			PlayerControl.fly = true;
		
			}
		}

	
		private void OnCollisionEnter(Collision collider){			
			if (collider.gameObject.tag == "NoMoveBolt") {
			Instantiate (lightning, transform.position, transform.rotation);
			//player.GetComponent<Rigidbody> ().useGravity = true;
			PlayerControl.fly = false;
				Destroy (target);
			}
		}
	}
	