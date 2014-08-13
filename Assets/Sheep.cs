using UnityEngine;
using System.Collections;

public class Sheep : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		while (i < Input.touchCount) {
			if(Input.GetTouch(i).phase == TouchPhase.Began) {			
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y));
				RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
				
				if (hit != null && hit.collider != null && hit.collider.gameObject == this.gameObject) {
					GetComponent<Animator>().SetTrigger("Flip");
					audio.Play();
				}
			}
			i++;
		}
	}
}
