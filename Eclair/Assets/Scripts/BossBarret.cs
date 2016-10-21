using UnityEngine;
using System.Collections;

public class BossBarret : MonoBehaviour {

	public GameObject player;
	public GameObject burn;

	public static bool bossShotAttack = false;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform);
		transform.position +=transform.forward * Time.deltaTime * 50;			
	}

	private void OnCollisionEnter (Collision collider)
	{
			Instantiate(burn,transform.position,transform.rotation);
			Destroy(gameObject);

		if (collider.gameObject.tag == "Player"){
			bossShotAttack = true;
		}
	}

}
