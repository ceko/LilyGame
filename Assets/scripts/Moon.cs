using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	StartCoroutine(Pulse());
	}

	// Update is called once per frame
	void Update () {
		int i = 0;
		while (i < Input.touchCount) {
			if(Input.GetTouch(i).phase == TouchPhase.Began) {			
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y));
				RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

				if (hit != null && hit.collider != null) {
					GameObject.Find("/Scenery/Night").GetComponent<NightManager>().HandleMoonClick();
				}
			}
			i++;
		}
	}
}
