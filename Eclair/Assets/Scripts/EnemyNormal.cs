using UnityEngine;
using System.Collections;

public class EnemyNormal : EnemyBase {

	public int maxHp;
	public int HP{ get; set; }

	// Use this for initialization
	void Start () {
		//maxHp = 15;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Damage(int damage){
		//HP -= damage;
	}
}
