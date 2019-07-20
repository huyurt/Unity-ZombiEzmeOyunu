using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuController : BaseController {

	private Rigidbody oyuncuBody;

	void Start () {
		oyuncuBody = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		KlavyeIleTankiHareketEttir ();
		RotasyonuDegistir ();
	}

	void FixedUpdate() {
		TankiHareketEttir();
	}

	void TankiHareketEttir() {
		oyuncuBody.MovePosition (oyuncuBody.position + hizVektoru * Time.deltaTime);
	}

	void KlavyeIleTankiHareketEttir(){
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			SolaHareket ();
		}

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			SagaHareket ();
		}

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			Hizlanma ();
		}

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			Yavaslama ();
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.A)) {
			IleriHareket ();
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.D)) {
			IleriHareket ();
		}

		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.W)) {
			Bosta ();
		}

		if (Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.S)) {
			Bosta ();
		}
	}

	void RotasyonuDegistir(){
		if (hizVektoru.x > 0) {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, maksimumAci, 0), Time.deltaTime * rotasyonHizi);
		} else if(hizVektoru.x < 0){
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -maksimumAci, 0), Time.deltaTime * rotasyonHizi);
		} else {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotasyonHizi);
		}
	}
}
