using UnityEngine;
using System.Collections;

public class Event2_10_way : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		GameObject.Find ("FadeOutPanel").GetComponent<AnimationQueueBase> ().Queue ();
		Camera.main.GetComponent<BGMController> ().Fade (1, BGMController.TransitionKind.Out);
		//MapLoader.Instance.startBoss ();
		MapLoader.Instance.Reset();
	}
}
