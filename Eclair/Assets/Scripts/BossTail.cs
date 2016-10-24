using UnityEngine;
using System.Collections;

public class BossTail : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void OnCollisionEnter (Collision collider)
	{
		//エトワールでぶつかったとき
		if(collider.gameObject.tag == "ETOEclair"){
			BossMoveManager.BossAttackedCount++;
			BossMoveManager.bossAttacked = true;
		}
		//SBTで攻撃したとき

}
}
