using UnityEngine;
using System.Collections;

public class TieMenEvent : MonoBehaviour {

	public AudioClip tieMenSound;//铁门声音
	public GameObject tieMenTrigger;

	void SoundEvent () {
		GetComponent<AudioSource>().PlayOneShot(tieMenSound);
		tieMenTrigger.SetActive(false);
	}
}
