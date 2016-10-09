using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimationQueue_Number : AnimationQueueBase {

	private Text text;
	private int currentNumber = 0;
	public int number = 10;
	public int step = 1;
	public bool useSign = false;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (text.enabled && currentNumber < number) {
			currentNumber += step;
			setText (currentNumber);
		} else if (currentNumber > number) {
			setText (number);
		}
	}

	public override void Queue(){
		text.enabled = true;
		text.text = "0";
	}

	private void setText(int num){
		text.text = num.ToString ();
		if (num > 0 && useSign)
			text.text = text.text.Insert (0, "+");
	}
}

