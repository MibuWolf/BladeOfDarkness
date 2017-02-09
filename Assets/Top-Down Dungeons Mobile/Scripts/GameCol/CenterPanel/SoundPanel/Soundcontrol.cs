using UnityEngine;
using System.Collections;

public class Soundcontrol : MonoBehaviour {

	private UISlider soundSlider;

	private Transform player;
	private AudioSource playerAudio;

	private Transform salesMan;
	private AudioSource salesAudio;

	private Transform boss;
	private AudioSource bossAudio;
	
	void Awake () {
		soundSlider = gameObject.GetComponent<UISlider>();
		player = GameObject.FindWithTag (Tags.player).transform;
		playerAudio = player.gameObject.GetComponent<AudioSource>();

		salesMan = GameObject.FindWithTag (Tags.salesMan).transform;
		salesAudio = salesMan.gameObject.GetComponent<AudioSource>();

		boss = GameObject.FindWithTag (Tags.boss).transform;
		bossAudio = boss.gameObject.GetComponent<AudioSource>();
	}
	
	void Update (){
		NGUITools.soundVolume = soundSlider.value;
		playerAudio.volume = soundSlider.value;
		salesAudio.volume = soundSlider.value;
		bossAudio.volume = soundSlider.value;
	}
}
