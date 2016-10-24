using UnityEngine;
using System.Collections;

public class EnemyNormal : EnemyBase {

	public int maxHp = 16;
	public int HP{ get; set; }

	// Use this for initialization
	void Start () {
		HP = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Damage(int damage,Vector3 direction){
		HP -= damage;
		Debug.Log ("ZakoHP:" + HP);
		if (HP <= 0) {
			Destroy (gameObject);
		}
	}
}
