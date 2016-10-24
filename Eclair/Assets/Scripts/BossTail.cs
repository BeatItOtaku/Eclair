using UnityEngine;
using System.Collections;

public class BossTail : EnemyBase {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Damage (int damage, Vector3 direction)
	{
		if (damage > 5)
			BossMoveManager.bossAttacked = true;
	}
}
