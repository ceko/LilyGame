using UnityEngine;
using System.Collections;

public class NightManager : MonoBehaviour {

	public GameObject Song;
	public GameObject Stars;

	// Use this for initialization
	void Start () {
		Song.GetComponent<AudioEventHelper>().OnAudioFinished += OnAudioFinished;
	}

	void OnAudioFinished (AudioEventHelper sender) {
		Stars.GetComponent<Stars>().StopAnimations();
		handlingMoonClick = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool handlingMoonClick = false;
	public void HandleMoonClick() {
		if (!handlingMoonClick) {
			handlingMoonClick = true;
			Song.GetComponent<AudioEventHelper>().PlayMusic();
			Stars.GetComponent<Stars>().AnimateChildren();
		}
	}

}
