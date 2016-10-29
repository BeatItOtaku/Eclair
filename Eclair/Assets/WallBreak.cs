using UnityEngine;
using System.Collections;

public class WallBreak : EnemyBase {

	public GameObject breakFire;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void Damage (int damage ,Vector3 direction)
	{
		if(damage >=15){
			Instantiate (breakFire, transform.position, transform.rotation);
			Destroy (gameObject);
	}
}
}
