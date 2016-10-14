using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

    public AudioClip select;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().PlayOneShot(select);
			NextLevel ();
            //TODO: シーン切り替え動作
        }
	}

	public void NextLevel(){
		Application.LoadLevelAsync (1);
	}
}
