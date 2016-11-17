using UnityEngine;
using System.Collections;

public class BossSceneManager : AnimationQueueManager {

    //CameraChanger cameraChanger = null;
    public BGMController bgm;
    public AudioClip intro;
    public AudioClip loop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBossDied()
    {
        bgm = Camera.main.GetComponent<BGMController>();
        bgm.Play(intro, loop, 1);
    }

}
