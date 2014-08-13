using UnityEngine;
using System.Collections;


public class Star : MonoBehaviour {

	private bool Animating;
	private System.Random rand;
	private ParticleSystem TwinkleEffect;

	// Use this for initialization
	void Start () {
		rand = new System.Random(GetInstanceID());
		GameObject twinklePrefab = GameObject.Instantiate(Resources.Load("TwinkleEffect") as GameObject) as GameObject;
		twinklePrefab.transform.parent = transform;
		twinklePrefab.transform.localPosition = Vector3.forward * -.1f; //make it come towards the camera a little bit so we can see the particles
		TwinkleEffect = twinklePrefab.GetComponent<ParticleSystem>();
		TwinkleEffect.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Animate() {
		TwinkleEffect.Play();
		Animating = true;
		float easeTime = rand.Next(4, 10);
		float scale = Random.Range (.6f, 1.2f);
		float rotation = rand.Next(0, 360);

		Go.to (transform, easeTime, new GoTweenConfig()
		    .setEaseType(GoEaseType.BounceInOut)
		    .scale (Vector3.one * scale)
		    .localRotation (new Vector3 (0f, 0f, rotation))
			.onComplete(GoTweenOnComplete)
		);
	}

	public void StopAnimations() {
		Animating = false;
		TwinkleEffect.Stop();
	}

	void GoTweenOnComplete (AbstractGoTween obj) {
		if(Animating)
			Animate();
	}
}
