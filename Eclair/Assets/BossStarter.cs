using UnityEngine;
using System.Collections;

public class BossStarter : MonoBehaviour {

	//public Vector3 bossPosition;
	public GameObject boss;
	public AudioClip bgm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(!col.CompareTag("Player")) return;
		Debug.Log ("StartBoss");
		StartBoss ();
	}

	void StartBoss(){
		boss.SetActive (true);
		Camera.main.GetComponent<BGMController> ().Play (null, bgm);
	}
}
