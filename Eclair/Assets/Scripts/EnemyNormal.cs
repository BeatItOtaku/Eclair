using UnityEngine;
using System.Collections;

public class EnemyNormal : EnemyBase {

	public int maxHp = 16;
	public int HP{ get; set; }

	public GameObject player;

	/// <summary>
	/// エクレアを感知する距離
	/// </summary>
	public float searchDistance = 16;

	// Use this for initialization
	void Start () {
		HP = maxHp;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, transform.position) < searchDistance) {
			//プレイヤーが近づいてる時
			transform.LookAt(player.transform.position);
			transform.position += transform.forward * Time.deltaTime;
		} else {
			transform.position += transform.forward * Time.deltaTime;
		}
	}

	public override void Damage(int damage,Vector3 direction){
		HP -= damage;
		Debug.Log ("ZakoHP:" + HP);
		if (HP <= 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		Debug.Log ("kougeki");
		if(col.gameObject.CompareTag("Player")){
			col.gameObject.GetComponent<PlayerControl> ().Damage (5);
		}
	}
}
