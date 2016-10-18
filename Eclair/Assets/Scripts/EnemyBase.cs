using UnityEngine;
using System.Collections;

public abstract class EnemyBase : MonoBehaviour {

	public int HP;
	public int maxHp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// ダメージを食らいます。
	/// 具体的には中のHPプロパティが減ります。
	/// </summary>
	/// <param name="damage">Damage.</param>
	public abstract void Damage (int damage);
}
