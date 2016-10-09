using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResultManager : MonoBehaviour {

	public GameObject frame;
	public GameObject title;

	private float time = 0;
	private int cursor = 0;

	//かなり頭悪いコード書くけど許して…！
	KeyValuePair<float,string>[] timeline = {
		new KeyValuePair<float,string>(0.5f,"Frame"),
		new KeyValuePair<float,string>(0.5f,"Title"),
		new KeyValuePair<float,string>(0.5f,"TimeLabel"),
		new KeyValuePair<float,string>(0.5f,"EnemyLabel"),
		new KeyValuePair<float,string>(0.5f,"BoltLabel")
	};

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (timeline.Length == cursor)
			return;
		if (timeline [cursor].Key < time) {
			GameObject.Find (timeline [cursor].Value).GetComponents<AnimationQueueBase>()[0].Queue ();
			Debug.Log (timeline [cursor].Value);
			time = 0;
			cursor++;
		}
	}
}
