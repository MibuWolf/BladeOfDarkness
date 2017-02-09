using UnityEngine;
using System.Collections;

public class MusicChange : MonoBehaviour {

	public AudioClip scene1Music;
	public float music1Volume;
	private AudioSource scene1_music;

	public AudioClip scene2Music;
	public float music2Volume;
	private AudioSource scene2_music;

	private UIPlaySound uiSound;

	void Awake () {
		scene1_music = gameObject.AddComponent<AudioSource>();
		scene1_music.clip = scene1Music;
		scene1_music.volume = music1Volume;

		scene2_music = gameObject.AddComponent<AudioSource>();
		scene2_music.clip = scene2Music;
		scene2_music.volume = music2Volume;
	}

	void Update () {
		Music1Play ();
	}

	void Music1Play () {
		scene1_music.Play ();
		scene2_music.Stop ();
	}

	void Music2Play () {
		scene1_music.Stop ();
		scene2_music.Play ();
	}
}
