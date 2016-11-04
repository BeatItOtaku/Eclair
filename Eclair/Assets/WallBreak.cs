using UnityEngine;
using System.Collections;

public class WallBreak : EnemyBase {

	public GameObject breakFire;

	public EventManager em;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void Damage (int damage ,Vector3 direction)
	{
			if (damage >= 30) {
				Instantiate (breakFire, transform.position, transform.rotation);
			em.EventCount ();
				Destroy (gameObject);
			}
		}
}

