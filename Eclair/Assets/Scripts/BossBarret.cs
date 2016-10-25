using UnityEngine;
using System.Collections;

public class BossBarret : MonoBehaviour {

	public GameObject player;
	public GameObject burn;

	public static bool bossShotAttack = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null) {	
			player = GameObject.FindGameObjectWithTag ("ETOEclair");
		} 
			transform.LookAt (player.transform);

	}

	// Update is called once per frame
	void Update () {
		
		transform.position +=transform.forward * Time.deltaTime*40;			
	}

	private void OnCollisionEnter (Collision collider)
	{

		if (collider.gameObject.tag == "Player"){
			bossShotAttack = true;
		}
		Instantiate(burn,transform.position,transform.rotation);
		Destroy (gameObject);
	}

}
