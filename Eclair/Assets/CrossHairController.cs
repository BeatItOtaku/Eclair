using UnityEngine;
using System.Collections;

/// <summary>
/// CrossHair(照準)にアタッチして使う
/// </summary>
public class CrossHairController : MonoBehaviour {

	private Animator anim;

	private bool isLockOn_ = false;
	/// <summary>
	/// 例によってInputManagerから操作する系のやつや
	/// </summary>
	/// <value><c>true</c> if the state is lock on; otherwise, <c>false</c>.</value>
	public bool isLockOn{
		get{
			return isLockOn_;
		}
		set{
			isLockOn_ = value;
			anim.SetBool ("isLockOn", isLockOn_);
		}
	}

	/// <summary>
	/// 画面上で照準が目指して移動する位置。(0,0)が左下っぽい？
	/// </summary>
	public Vector2 target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
