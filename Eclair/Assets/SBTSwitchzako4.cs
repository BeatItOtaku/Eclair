﻿using UnityEngine;
using System.Collections;

public class SBTSwitchzako4: EnemyBase {

	public MeshRenderer meshrender;
	public GameObject lightSphere;
	public GameObject glass;
	public EventManager2 em2;

	public static bool SBT4On;

	private float OnTime;

	// Use this for initialization
	void Start () {
		(glass.GetComponent ("Halo") as Behaviour).enabled = false;
		SBT4On = false;
		OnTime = 0;
	}

	// Update is called once per frame
	void Update () {
		if (SBT4On == true) {
			OnTime += Time.deltaTime;
		} else {
			OnTime = 0;
		}

		if (OnTime >= 2.0f && em2.eventCount2 == 3 && SBT4On == true) {
			lightSphere.SetActive (true);
			meshrender.material.color = new Color (0, 0, 0, 1.0f);
			(glass.GetComponent ("Halo") as Behaviour).enabled = false;
			SBT4On = false;
		}

	}
	public override void Damage(int damage ,Vector3 direction){
		if (damage == 15 && meshrender.material.color.a != 0.5f)  {
			lightSphere.SetActive (false);
			meshrender.material.color = new Color (0, 0, 0, 0.5f);
			(glass.GetComponent ("Halo") as Behaviour).enabled = true;
			SBT4On = true;


		}

	}
}
