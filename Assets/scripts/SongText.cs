using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SongText : MonoBehaviour {

	public GameObject BouncingBall;
	private bool Running;
	private TextMesh TopText;
	private TextMesh BottomText;

	private List<string> Lyrics;

	// Use this for initialization
	void Start () {
		TopText = transform.Find("Top Line").GetComponent<TextMesh>();
		BottomText = transform.Find("Bottom Line").GetComponent<TextMesh>();
		Lyrics = new List<string> {
			"Twinkle Twinkle",
			"Little Star",
			"How I Wonder",
			"What You Are",
			"Up Above The",
			"World So High",
			"Like A Diamond",
			"In The Sky",
			"Twinkle Twinkle",
			"Little Star",
			"How I Wonder",
			"What You Are"
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public IEnumerator StartSingalong() {
		TopText.color = new Color(TopText.color.r, TopText.color.g, TopText.color.b, 1f);
		BottomText.color = new Color(BottomText.color.r, BottomText.color.g, BottomText.color.b, 1f);

		Vector3 originalMoonPosition = BouncingBall.transform.position;
		yield return new WaitForSeconds(2.5f);
		BouncingBall.transform.Find("Moon").GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";

		for(int i=0;i<Lyrics.Count;i+=2) {
			TopText.text = Lyrics[i];
			BottomText.text = Lyrics[i+1];

			BouncingBall.transform.positionTo(.5f, TopText.gameObject.transform.position + Vector3.up * .6f + Vector3.left * (TopText.renderer.bounds.max.x/2));
			yield return new WaitForSeconds(4.75f/4f);
			BouncingBall.transform.positionTo(.5f, TopText.gameObject.transform.position + Vector3.up * .6f + Vector3.right * (TopText.renderer.bounds.max.x/2));
			yield return new WaitForSeconds(4.75f/4f);
			BouncingBall.transform.positionTo(.5f, BottomText.gameObject.transform.position + Vector3.up * .6f + Vector3.left * (BottomText.renderer.bounds.max.x/2));
			yield return new WaitForSeconds(4.75f/4f);
			BouncingBall.transform.positionTo(.5f, BottomText.gameObject.transform.position + Vector3.up * .6f + Vector3.right * (BottomText.renderer.bounds.max.x/2));
			yield return new WaitForSeconds(4.75f/4f);
		}

		yield return new WaitForSeconds(1f);
		BouncingBall.transform.positionTo(10f, originalMoonPosition);
		StartCoroutine(FadeOutText());

		BouncingBall.transform.Find("Moon").GetComponent<Moon>().StopBouncing();
		yield return new WaitForSeconds(10f);
		BouncingBall.transform.Find("Moon").GetComponent<SpriteRenderer>().sortingLayerName = "Background";
		yield return null;
	}

	private IEnumerator FadeOutText() {
		for(float i=3;i>=0f;i-=Time.deltaTime) {
			TopText.color = new Color(TopText.color.r, TopText.color.g, TopText.color.b, i/3f);
			BottomText.color = new Color(BottomText.color.r, BottomText.color.g, BottomText.color.b, i/3f);
			yield return null;
		}

		TopText.text = "";
		BottomText.text = "";
	}

}
