using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimationQueue_Number : AnimationQueueBase {

	private Text text;
	private int currentNumber = 0;
	public int number = 10;
	public int step = 1;
	public bool useSign = false;

	private bool positive;//trueなら正の値,falseなら負の値

	// Use this for initialization
	void Start () {
		positive = (number > 0);
		number = (int)Mathf.Abs (number);
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
        positive = (number > 0);
        number = (int)Mathf.Abs(number);
    }

	private void setText(int num){
		string sign = "";
		if (useSign || !positive)
			sign = (positive ? "+" : "-");
		text.text = sign + num.ToString ();
		//text.text = text.text.Insert (0, "+");
	}
}

