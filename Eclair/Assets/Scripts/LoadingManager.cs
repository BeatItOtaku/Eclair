using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoadingManager : MonoBehaviour {

	private float time = 0;
	private int cursor = 0;

	private bool nextButtonShown = false;

	private GameObject loading;//走るエクレアとかがあるやつ

	//かなり頭悪いコード書くけど許して…！
	KeyValuePair<float,string>[] timeline = {
        new KeyValuePair<float,string>(0.1f,"Wall"),
        new KeyValuePair<float,string>(0,"TitleBack"),
        new KeyValuePair<float,string>(1.0f,"WhatIsEclair"),
		new KeyValuePair<float,string>(0.5f,"Eclair"),
		new KeyValuePair<float,string>(0.1f,"EclairCanDo"),
		new KeyValuePair<float,string>(0.1f,"AutoNextButton"),
		new KeyValuePair<float,string>(-1,"AutoNextButton"),
		new KeyValuePair<float,string>(0.1f,"Eclair"),
		new KeyValuePair<float,string>(0.1f,"EclairCanDo"),
		new KeyValuePair<float,string>(0.1f,"WhatIsEclair"),
		new KeyValuePair<float,string>(0.0f,"HowToControl"),
		new KeyValuePair<float,string>(0.2f,"KeyboardAndMouse"),
		new KeyValuePair<float,string>(0.1f,"GamePad"),
	};

	// Use this for initialization
	void Start () {
		CameraController.cursorIsLocked = false;
		loading = GameObject.Find ("Loading");
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (timeline.Length == cursor)
			return;
		if (0 <= timeline [cursor].Key) {
			if (timeline [cursor].Key < time) {
				Invoke ();
			}
		}
		if (MapLoader.Instance.isLoaded && !nextButtonShown) {
			//Debug.Log (cursor);
			if (cursor > 12) {
				//Debug.Log ("hoge");
				loading.SetActive (false);
				GameObject.Find ("StartButton").GetComponents<AnimationQueueBase> ()[0].Queue ();
				nextButtonShown = true;
			}
		}
	}

	public void startGame(){
		MapLoader.Instance.startGame ();
	}

	public void Invoke(){
		GameObject.Find (timeline [cursor].Value).GetComponents<AnimationQueueBase> () [0].Queue ();//抽象クラス最高！
		//Debug.Log (timeline [cursor].Value);
		time = 0;
		cursor++;
	}

}
