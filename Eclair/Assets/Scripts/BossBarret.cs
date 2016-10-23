using UnityEngine;
using System.Collections;

public class BossBarret : MonoBehaviour {

	public GameObject player;
	public GameObject burn;

	public static bool bossShotAttack = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		transform.LookAt (player.transform);

	}

	// Update is called once per frame
	void Update () {
		
		transform.position +=transform.forward * Time.deltaTime*20;			
	}

	private void OnCollisionEnter (Collision collider)
	{

		if (collider.gameObject.tag == "Player"){
			Instantiate(burn,transform.position,transform.rotation);
			bossShotAttack = true;
			Destroy(gameObject);
		}
		Instantiate(burn,transform.position,transform.rotation);
		Destroy (gameObject);
	}

}
