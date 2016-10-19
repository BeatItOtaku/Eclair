using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TitleManager : MonoBehaviour {

    public AudioClip select;
    public Text loadingText;

    public MapLoader scene;

    private bool isLoading = false;

    // Use this for initialization
    void Start () {
        CameraController.cursorIsLocked = false;
        scene = MapLoader.Instance;
        //scene.startMapLoad();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(select);
			NextLevel ();
            //TODO: シーン切り替え動作
        }
        if (isLoading && loadingText != null)
        {
            //loadingText.text = "Now Loading... " + (scene.MapAsync.progress * 100).ToString("F0") + "%";
        }
    }

	public void NextLevel(){
        //SceneManager.LoadSceneAsync (1);
        LoadScene();
	}

    private void LoadScene()
    {
		SceneManager.LoadSceneAsync ("Loading", LoadSceneMode.Additive);
        scene.startMapLoad();
        loadingText.enabled = true;
        isLoading = true;
        scene.startGame();
    }
}
