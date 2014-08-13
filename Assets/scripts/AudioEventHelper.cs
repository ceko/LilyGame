using UnityEngine;
using System.Collections;

public class AudioEventHelper : MonoBehaviour {

	float audioWait;
	bool clipPlaying;

	public delegate void AudioFinishedHandler(AudioEventHelper sender);
	public event AudioFinishedHandler OnAudioFinished;

	// Use this for initialization
	void Start () {
	
	}

	void Update() {
		if(clipPlaying) {
			audioWait -= Time.deltaTime;
			if(audioWait <= 0) {
				clipPlaying = false;
				if(OnAudioFinished != null) OnAudioFinished(this);
				Debug.Log ("Done playing");
			}
		}
	}

	// Update is called once per frame
	public void PlayMusic() {
		if(!clipPlaying) {
			clipPlaying = true;
			audio.Play();
			audioWait = audio.clip.length;				
		}
	}
}
