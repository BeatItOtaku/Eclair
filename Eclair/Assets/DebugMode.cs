using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour {

    private Text textBox;
    public InputManager inputManager;

	// Use this for initialization
	void Start () {
        textBox = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
       // textBox.text = inputManager.getDebugString();
	}
}
