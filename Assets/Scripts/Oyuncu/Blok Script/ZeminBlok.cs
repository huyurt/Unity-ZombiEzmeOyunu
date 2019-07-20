using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminBlok : MonoBehaviour {

	public Transform digerBlok;
	public float halfLength = 100f;
	private Transform oyuncu;
	private float endOffset = 10f;

	void Start () {
		oyuncu = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void Update () {
		ZeminHareketi ();
	}

	void ZeminHareketi(){
		if(transform.position.z + halfLength < oyuncu.transform.position.z - endOffset){
			transform.position = new Vector3 (digerBlok.position.x, digerBlok.position.y, digerBlok.position.z + halfLength * 2);
		}
	}
}
