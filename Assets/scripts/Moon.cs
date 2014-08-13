using UnityEngine;
using System.Collections;
using System.Linq;


public class Moon : MonoBehaviour {

	bool songPlaying = false;
	bool bouncing = false;

	// Use this for initialization
	void Start () {
		StopParticleEffects();
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		while (i < Input.touchCount) {
			if(Input.GetTouch(i).phase == TouchPhase.Began) {			
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y));
				RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

				if (hit != null && hit.collider != null && hit.collider.gameObject == this.gameObject) {
					if(!songPlaying) {
						songPlaying = true;
						GameObject.Find("/Scenery/Night").GetComponent<NightManager>().HandleMoonClick();
						GetComponent<Animator>().SetTrigger("PlayingSong");
						bouncing = true;
						foreach(ParticleSystem system in transform.GetComponentsInChildren<ParticleSystem>()) {
							system.Play();
						}
					}
				}
			}
			i++;
		}
	}

	public void StopBouncing() {
		if(bouncing)
			GetComponent<Animator>().SetTrigger("SongFinished");
		bouncing = false;
	}

	public void SongFinished() {
		StopBouncing();
		StopParticleEffects();
		songPlaying = false;
	}

	private void StopParticleEffects() {
		foreach(ParticleSystem system in transform.GetComponentsInChildren<ParticleSystem>()) {
			system.Stop();
		}
	}
}
