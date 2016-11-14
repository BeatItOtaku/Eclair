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
    public float mutekiTime = 0.8f;

	public GameObject player;
    private Animator anim;

    private bool isMuteki;

	private GameObject em;
	/// <summary>
	/// エクレアを感知する距離
	/// </summary>
	public float searchDistance = 16;
    public float moveDistance = 64;

	// Use this for initialization
	void Start () {
		HP = maxHp;
		player = GameObject.FindGameObjectWithTag ("Player");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(player == null) player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < searchDistance) {
            //プレイヤーが近づいてる時
            anim.enabled = true;
            anim.SetBool("isAttacking", true);
			transform.LookAt(player.transform.position);
			//transform.position += transform.forward * attackSpeed * Time.deltaTime;
		} else if (distance < moveDistance){
            anim.enabled = true;
            anim.SetBool("isAttacking", false);
            //transform.position += transform.forward * normalSpeed * Time.deltaTime;
        }else
        {
            anim.enabled = false;
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
            ScoreCounter.EnemyBeated();
        }
        else
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            lookRotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
            transform.rotation = lookRotation;
            if (damage < 6) anim.SetTrigger("Defend");
            else anim.SetTrigger("Damaged");
            startMuteki();

        }
        //Debug.Log ("ZakoHP:" + HP);

	}

    IEnumerator startMuteki()
    {
        if (!isMuteki)
        {
            isMuteki = true;
            yield return new WaitForSeconds(mutekiTime);
            isMuteki = false;
        }

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
