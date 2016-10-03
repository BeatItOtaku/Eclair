using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ロックオン対象のGameObjectを取得するだけです。
/// GUIへの描画などは別のスクリプトで行います。
/// </summary>
public class LockOn : MonoBehaviour {

	List<KeyValuePair<float, GameObject>> targetList = new List<KeyValuePair<float, GameObject>>();
	public GameObject player;

	private int cursor = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject startLockOn(){
		foreach(GameObject go in GameObject.FindGameObjectsWithTag ("Bolt")){
			float distance = Vector3.Distance (player.transform.position, go.transform.position);
			targetList.Add(new KeyValuePair<float, GameObject>(distance,go));
		}
		targetList.Sort (CompareKeyValuePair);
		cursor = 0;
		return targetList [cursor].Value;
	}
	public void endLockOn(){
		return;
	}

	public GameObject Switch(){
		cursor++;
		if (cursor >= targetList.Count) cursor = 0;
		return targetList [cursor].Value;
	}

	// 二つのKeyValuePair<string, int>を比較するためのメソッド
	static int CompareKeyValuePair(KeyValuePair<float, GameObject> x, KeyValuePair<float, GameObject> y)
	{
		// Keyで比較した結果を返す
		return Mathf.Min(x.Key, y.Key);
	}
}
