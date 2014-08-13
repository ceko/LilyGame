using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach(Transform child in transform) {
			child.gameObject.AddComponent<Star>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StopAnimations() {
		foreach(Transform child in transform) {
			child.gameObject.GetComponent<Star>().StopAnimations();
		}
	}

	public void AnimateChildren() {
		foreach(Transform child in transform) {
			child.gameObject.GetComponent<Star>().Animate();
		}
	}

}
