using UnityEngine;
using System.Collections;

public class ZakoSpown : MonoBehaviour {

	public GameObject spownPoint;

	public GameObject zako;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag == "Player"){
			for(int x=0; x<=3; ++x)
			{
				Instantiate(zako,spownPoint.transform.position,spownPoint.transform.rotation);
			}
}
	}
}
