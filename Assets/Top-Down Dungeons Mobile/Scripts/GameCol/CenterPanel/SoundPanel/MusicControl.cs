using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {

	private AudioSource audio;
	private Transform playerCamera;

	private UISlider musicSlider;

	void Awake () {
		playerCamera = GameObject.FindWithTag (Tags.playerCamera).transform;
		audio = playerCamera.gameObject.GetComponent<AudioSource>();
		musicSlider = gameObject.GetComponent<UISlider>();
	}

	void Update () {
		audio.volume = musicSlider.value;
	}
}
