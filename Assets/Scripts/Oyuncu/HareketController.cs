using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketController : MonoBehaviour {

	public Vector3 hizVektoru;
	public float x_Hiz = 8, z_Hiz = 15;
	public float hizlanma = 15, yavaslama = 10;
	protected float acisalHiz = 10;
	protected float maksimumAci = 10;

	public float dusukSes, normalSes, yuksekSes;
	public AudioClip motorSesiAcik, motorSesiKapali;

	private AudioSource sesYoneticisi;
	private bool yavasliyorMu;

	void Awake () {
		sesYoneticisi = GetComponent<AudioSource> ();

		hizVektoru = new Vector3 (0, 0, z_Hiz);
	}

	protected void IleriHareket(){
		hizVektoru = new Vector3 (0, 0, hizVektoru.z);
	}

	protected void SagaHareket(){
		hizVektoru = new Vector3 (x_Hiz / 2, 0, hizVektoru.z);
	}

	protected void SolaHareket(){
		hizVektoru = new Vector3 (-x_Hiz / 2, 0, hizVektoru.z);
	}

	protected void Hizlanma(){
		hizVektoru = new Vector3 (hizVektoru.x, 0, hizlanma);
	}

	protected void Yavaslama(){
		if (!yavasliyorMu) {
			yavasliyorMu = true;

			sesYoneticisi.Stop ();
			sesYoneticisi.clip = motorSesiKapali;
			sesYoneticisi.volume = 0.5f;
			sesYoneticisi.Play ();
		}
		hizVektoru = new Vector3 (hizVektoru.x, 0, yavaslama);
	}

	protected void Bosta(){
		if (yavasliyorMu) {
			yavasliyorMu = false;

			sesYoneticisi.Stop ();
			sesYoneticisi.clip = motorSesiAcik;
			sesYoneticisi.volume = 0.3f;
			sesYoneticisi.Play ();
		}
		hizVektoru = new Vector3 (hizVektoru.x, 0, z_Hiz);
	}
}
