using UnityEngine;
using System.Collections;

public class EnemyNormal : EnemyBase {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Damage(int damage){
		HP -= 10;
	}
}
