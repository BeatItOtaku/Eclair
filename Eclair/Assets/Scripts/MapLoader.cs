using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapLoader : MonoBehaviour
{
    private static MapLoader mInstance;

    public AsyncOperation MapAsync;

    private bool startGameFlag = false;

	public bool isLoaded{
		get{
			return MapAsync.progress >= 0.9f;
		}
	}

    private MapLoader()
    {
        //startMapLoad();
        //Debug.Log("Create SampleSingleton instance.");
    }

    public static MapLoader Instance
    {

        get
        {

            if (mInstance == null)
            {
                GameObject go = new GameObject("MapLoader");
                mInstance = go.AddComponent<MapLoader>();
            }

            return mInstance;
        }
    }

    public void startMapLoad()
    {
        if (MapAsync == null)
        {
            MapAsync = SceneManager.LoadSceneAsync("BiO Map");//, LoadSceneMode.Additive);
            MapAsync.allowSceneActivation = false;
        }
    }

    public void startGame()
    {
        startGameFlag = true;
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        //startMapLoad();
    }

    void Update()
    {
        //Debug.Log(MapAsync.progress);
        if(startGameFlag && MapAsync.progress >= 0.9f)
        {
            //Debug.Log("aho");
            MapAsync.allowSceneActivation = true;
			PlayerControl.EclairImmobile = false;
            SceneManager.LoadSceneAsync("tougou",LoadSceneMode.Additive);
			SceneManager.LoadSceneAsync ("Boss Map", LoadSceneMode.Additive);
            startGameFlag = false;
            MapAsync = null;
        }

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
			if(InputManager.isGamePad) InputManager.isGamePad = false;
		} else if (Mathf.Abs (Input.GetAxisRaw ("Camera Y")) > 0.4f || Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.4f) {
			if(!InputManager.isGamePad) InputManager.isGamePad = true;//WASDが押されてないのに移動してる => ゲームパッドを触ってる
		}
    }

    void OnApplicationQuit()
    {
        MapAsync = null;//Debug.Log("Application ending after " + Time.time + " seconds");
    }

	

}
