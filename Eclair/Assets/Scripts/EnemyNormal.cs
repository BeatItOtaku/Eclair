using UnityEngine;
using System.Collections;

public class EnemyNormal : EnemyBase {

	public int maxHp = 15;
    public int attackReaction = 4;
    public int damageReaction = 6;
	public int HP{ get; set; }

	public GameObject player;
    private Animator anim;

	/// <summary>
	/// エクレアを感知する距離
	/// </summary>
	public float searchDistance = 16;

	// Use this for initialization
	void Start () {
		HP = maxHp;
		player = GameObject.FindGameObjectWithTag ("Player");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, transform.position) < searchDistance) {
            //プレイヤーが近づいてる時
            anim.SetBool("isAttacking", true);
			transform.LookAt(player.transform.position);
			transform.position += transform.forward * Time.deltaTime;
		} else {
            anim.SetBool("isAttacking", false);
            transform.position += transform.forward * Time.deltaTime;
		}
	}

	public override void Damage(int damage,Vector3 direction){
		HP -= damage;
        if (HP <= 0)
        {
            anim.SetTrigger("Died");
            Destroy(gameObject, 1.0f);
        }
        else
        {
            anim.SetTrigger("Damaged");
            GetComponent<Rigidbody>().AddForce(-transform.forward * damageReaction, ForceMode.VelocityChange);
        }
        Debug.Log ("ZakoHP:" + HP);

	}

	void OnCollisionEnter(Collision col){
		Debug.Log ("kougeki");
		if(col.gameObject.CompareTag("Player")){
            anim.SetTrigger("Attack");
			col.gameObject.GetComponent<PlayerControl> ().Damage (5);
            GetComponent<Rigidbody>().AddForce(-transform.forward * attackReaction, ForceMode.VelocityChange);
		}
	}
}
