using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossSceneManager : AnimationQueueManager {

    //CameraChanger cameraChanger = null;
    public BGMController bgm;
    public AudioClip bossBGMIntro;
    public AudioClip bossBGMLoop;
    public AudioClip resultBGMIntro;
    public AudioClip resultBGMLoop;

    private AsyncOperation result;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        result = SceneManager.LoadSceneAsync("Result", LoadSceneMode.Additive);
        result.allowSceneActivation = false;
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
	}

    protected override void OnCursorChanged(int before, int after)
    {
        base.OnCursorChanged(before, after);
        Debug.Log("BossSceneManager:" + after);
        switch (after)
        {
            case 2:
                bgm = GameObject.Find("Main Camera").GetComponent<BGMController>();
                bgm.Play(bossBGMIntro, bossBGMLoop, 1);
                break;
            case 3:
                CameraChanger.CurrentCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
                break;
            case 4:
                bgm.Stop();
                break;
            case 5:
                OnBossDied();
                break;
            case 6:
                result.allowSceneActivation = true;
                break;
        }
    }

    public void OnBossDied()
    {
        //bgm = Camera.main.GetComponent<BGMController>();
        bgm.Play(resultBGMIntro, resultBGMLoop, 1);
    }

}
