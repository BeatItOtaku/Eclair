using UnityEngine;
using System.Collections;

public class BossFootCollider : MonoBehaviour {

	public static bool bossFootAttack = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//footTime += Time.deltaTime;;
	
	}
	private void OnCollisionEnter (Collision collider)
	{
		if (collider.gameObject.tag == "Player") {

				bossFootAttack = true;
	}
			
}
}
