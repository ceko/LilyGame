using UnityEngine;

public class PositionCamera : MonoBehaviour {

	public float fWidth = 9.0f;  // Desired width 

	void Start () {
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		float fT = fWidth / Screen.width * Screen.height;
		fT = fT / (2.0f * Mathf.Tan (0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad));
		Vector3 v3T = Camera.main.transform.position;
		v3T.z = -fT;
		transform.position = v3T;
	}
			    
}