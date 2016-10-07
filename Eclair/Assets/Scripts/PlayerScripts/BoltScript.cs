﻿using UnityEngine;
using System.Collections;

public class BoltScript : MonoBehaviour {

    public float scaleWhenCollided = 1.0f;
    public Vector3 collidedRotateOffset;
	
	// Use this for initialization
	void Start () {

	}

	public Vector3 Target {
		get;
		set;
	}

    public Quaternion TargetQuaternion { get; set; }

	// Update is called once per frame
	void Update () {
		//Destroy (gameObject, 3);
		//弾を前進させる
		//transform.position += transform.forward *Time.deltaTime * 70 ;
		//Debug.Log(gameObject.transform.position);
	}

	void OnCollisionEnter(Collision collider)
	{	
		if (collider.gameObject.tag == "Player")
			return;
		
		//Debug.Log ("hoge");
		try {gameObject.GetComponent<LinearMovement> ().Speed = 0;}
		catch {
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}

        if (Target == null) return;

		gameObject.transform.position = Target;
        Debug.Log(TargetQuaternion.eulerAngles);
        TargetQuaternion *= Quaternion.Euler(collidedRotateOffset);
        if(TargetQuaternion != Quaternion.Euler(0,0,0)) gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, TargetQuaternion, 0.8f);
        gameObject.transform.localScale *= scaleWhenCollided;

	}
}
