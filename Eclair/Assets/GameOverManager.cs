using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverManager : AnimationQueueManager {

    protected override void Start()
    {
        base.Start();
        CameraController.cursorIsLocked = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reset()
    {
        StartCoroutine(coroutine());
    }
    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(0.5f);
        MapLoader.Reset();
    }


    public void Continue()
    {
        MapLoader.ReloadScene();
    }
}
