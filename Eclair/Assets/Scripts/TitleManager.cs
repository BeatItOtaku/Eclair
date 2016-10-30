using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TitleManager : MonoBehaviour {

    public AudioClip select;
    //public Text loadingText;

    private MapLoader scene;

    private bool isLoading = false;

    // Use this for initialization
    void Start () {
        CameraController.cursorIsLocked = false;
        scene = MapLoader.Instance;
        //scene.startMapLoad();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<AudioSource>().PlayOneShot(select);
			NextLevel ();
            //TODO: シーン切り替え動作
        }
    }

	public void NextLevel(){
        //SceneManager.LoadSceneAsync (1);
        LoadScene();
	}

    private void LoadScene()
    {
		if (isLoading)
			return;
		
		SceneManager.LoadSceneAsync ("Loading", LoadSceneMode.Additive);
		if(!Application.isEditor) scene.startMapLoad();
        isLoading = true;
        scene.startGame();
    }
}
