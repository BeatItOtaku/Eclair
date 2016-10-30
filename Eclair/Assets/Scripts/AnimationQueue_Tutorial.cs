using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class AnimationQueue_Tutorial : AnimationQueueBase {

	private int phase = 0;

	public AnimationQueueBase large;
	public AnimationQueueBase small;

	public Sprite largeKey,smallKey,largePad,smallPad;

	private float time = 0;

	// Use this for initialization
	void Start () {
		/*foreach(AnimationQueueBase a in GetComponentsInChildren<AnimationQueueBase> ()){
			if (a.gameObject.name == "Large") {
				large = a;
			} else if (a.gameObject.name == "Small") {
				small = a;
			}
		}*/
		onControllerChanged (InputManager.isGamePad);
	}
	
	// Update is called once per frame
	void Update () {
		if (phase == 1) {
			time += Time.deltaTime;
			if (time > 0.4f) {
				small.Queue ();
				phase = 2;
			}
		}
	}

	public override void Queue(){
		//Debug.Log ("aho");
		switch (phase) {
		case 0:
			large.Queue ();
			break;

		case 1:
			large.Queue ();
			break;


		case 3:
			small.Queue ();
			break;
		}
		phase++;
	}

	public void onControllerChanged(bool isGamePad){
		if (isGamePad) {
			large.GetComponent<Image> ().sprite = largePad;
			small.GetComponent<Image> ().sprite = smallPad;
		} else {
			large.GetComponent<Image> ().sprite = largeKey;
			small.GetComponent<Image> ().sprite = smallKey;
		}
	}
}
