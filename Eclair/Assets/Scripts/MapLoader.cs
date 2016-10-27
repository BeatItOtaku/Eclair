using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapLoader : MonoBehaviour
{

    private static MapLoader mInstance;

    public AsyncOperation MapAsync;

    private bool startGameFlag = false;


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
            SceneManager.LoadSceneAsync("Player",LoadSceneMode.Additive);
            startGameFlag = false;
            MapAsync = null;
        }
    }

    void OnApplicationQuit()
    {
        MapAsync = null;//Debug.Log("Application ending after " + Time.time + " seconds");
    }

}
