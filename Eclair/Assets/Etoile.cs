using UnityEngine;
using System.Collections;

//エクレアが電気になって移動する技「エトワール（etoile)」用のスクリプト。

public class Etoile : MonoBehaviour {

	public GameObject Player;
	public GameObject go = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Aim")) Attack(FindClosestEnemy());

	
	}

void Attack(GameObject go){
	if (go != null){
		Quaternion targetRotation = Quaternion.LookRotation (go.transform.position - Player.transform.position);
			Player.transform.rotation = targetRotation;

	}
}
GameObject FindClosestEnemy(){

	GameObject[] gos;
	gos = GameObject.FindGameObjectsWithTag("NoMoveBolt");
	GameObject closest = null;
	float distance = Mathf.Infinity;
	Vector3 Position = transform.position;

	foreach (GameObject go in gos){

		Vector3 diff = go.transform.position - Position;
		float curDistance = diff.sqrMagnitude;

		if(curDistance < distance){
			closest = go;
			distance = curDistance;
		}
	}
	return closest;
}
}
