 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResultManager : MonoBehaviour {

	private float time = 0;
	private int cursor = 0;

	//かなり頭悪いコード書くけど許して…！
	KeyValuePair<float,string>[] timeline = {
		new KeyValuePair<float,string>(0.5f,"Frame"),
		new KeyValuePair<float,string>(0.4f,"Title"),
		new KeyValuePair<float,string>(0.5f,"TimeLabel"),
		new KeyValuePair<float,string>(0.5f,"TimeText"),
		new KeyValuePair<float,string>(0.5f,"TimeRank"),
		new KeyValuePair<float,string>(0.2f,"TimeScore"),
		new KeyValuePair<float,string>(0.5f,"EnemyLabel"),
		new KeyValuePair<float,string>(0.5f,"EnemyText"),
		new KeyValuePair<float,string>(0.5f,"EnemyRank"),
		new KeyValuePair<float,string>(0.2f,"EnemyScore"),
		new KeyValuePair<float,string>(0.5f,"BoltLabel"),
		new KeyValuePair<float,string>(0.5f,"BoltText"),
		new KeyValuePair<float,string>(0.5f,"BoltRank"),
		new KeyValuePair<float,string>(0.2f,"BoltScore"),
		new KeyValuePair<float,string>(1.0f,"Horizon"),
		new KeyValuePair<float,string>(0.3f,"TotalLabel"),
		new KeyValuePair<float,string>(0.5f,"TotalText"),
		new KeyValuePair<float,string>(1.8f,"TotalRank"),
		new KeyValuePair<float,string>(1.0f,"NextButton"),
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
			//Debug.Log (timeline [cursor].Value);
			time = 0;
			cursor++;
		}
	}
}
