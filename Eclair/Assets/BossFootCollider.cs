using UnityEngine;
using System.Collections;

public class BossFootCollider : MonoBehaviour {

	public static bool bossFootAttack = false;

	//private float footTime =0; //ボスが足を振り下ろす間隔を表現するための時間
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (bossFootAttack);
		//footTime += Time.deltaTime;;
	
	}
	private void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Player") {

				bossFootAttack = true;
	}
			
}
}
