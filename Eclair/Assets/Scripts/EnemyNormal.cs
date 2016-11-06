using UnityEngine;
using System.Collections;

public class EnemyNormal : EnemyBase {

	public int maxHp = 15;
    public int attackReaction = 4;
    public int damageReaction = 6;
	public int dieReaction = 2;
	public int HP{ get; set; }
	public float normalSpeed = 2;
	public float attackSpeed = 4;

	public GameObject player;
    private Animator anim;

	private GameObject em;
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
        if(player == null) player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance (player.transform.position, transform.position) < searchDistance) {
            //プレイヤーが近づいてる時
            anim.SetBool("isAttacking", true);
			transform.LookAt(player.transform.position);
			transform.position += transform.forward * attackSpeed * Time.deltaTime;
		} else {
            anim.SetBool("isAttacking", false);
			transform.position += transform.forward * normalSpeed * Time.deltaTime;
		}
	}

	public override void Damage(int damage,Vector3 direction){
		HP -= damage;
		GetComponent<Rigidbody>().velocity = (-transform.forward * damageReaction);
        if (HP <= 0)
        {
            anim.SetTrigger("Died");
			GetComponent<Rigidbody> ().constraints = new RigidbodyConstraints ();
			GetComponent<Rigidbody> ().velocity += transform.up * dieReaction;
            Destroy(gameObject, 1.2f);
			if (EventManager.eventCount == 3) {
				em = GameObject.Find ("EventManager");
				em.GetComponent<EventManager> ().EventCount ();
			}
        }
        else
        {
            anim.SetTrigger("Damaged");

        }
        //Debug.Log ("ZakoHP:" + HP);

	}

	void OnCollisionEnter(Collision col){
		//Debug.Log ("kougeki");
		if(col.gameObject.CompareTag("Player")){
            anim.SetTrigger("Attack");
			col.gameObject.GetComponent<PlayerControl> ().Damage (5);
			GetComponent<Rigidbody>().velocity = (-transform.forward * attackReaction);
		}
	}
}
