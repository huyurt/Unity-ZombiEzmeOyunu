using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

	Transform hedef;

	public float uzaklik = 6.3f;
	public float yukseklik = 3.5f;

	public float yukseklikDamping = 3.25f;
	public float rotasyonDamping = 0.27f;

	void Start () {
		hedef = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void LateUpdate () {
		OyuncuyuTakipEt ();
	}

	void OyuncuyuTakipEt(){
		float istenenRotasyonAcisi = hedef.eulerAngles.y;
		float istenenYukseklik = hedef.position.y + uzaklik;

		float suankiRotasyonAcisi = transform.eulerAngles.y;
		float suankiYukseklik = transform.position.y;

		suankiRotasyonAcisi = Mathf.LerpAngle (suankiRotasyonAcisi, istenenRotasyonAcisi, rotasyonDamping * Time.deltaTime);
		suankiYukseklik = Mathf.Lerp (suankiYukseklik, istenenYukseklik, yukseklikDamping * Time.deltaTime);

		Quaternion suankiRotasyon = Quaternion.Euler (0, suankiRotasyonAcisi, 0);

		transform.position = hedef.position;
		transform.position -= suankiRotasyon * Vector3.forward * uzaklik;
		transform.position = new Vector3 (transform.position.x, suankiYukseklik, transform.position.z);
	}
}
