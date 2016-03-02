using UnityEngine;
using System.Collections;

public class DimensionTakeOver : MonoBehaviour {

	public Camera dimensionOneCamera;
	public Camera dimensionTwoCamera;

	public DimensionPreferance dp = DimensionPreferance.Neither;

	void Update() {

		if (Input.GetKey(KeyCode.O)){
			dp = DimensionPreferance.D1;
		} else if (Input.GetKey(KeyCode.P)){
			dp = DimensionPreferance.D2;
		} else if (Input.GetKey(KeyCode.N)){
			dp = DimensionPreferance.Neither;
		}

		if (dp == DimensionPreferance.D1)
			dimensionOneCamera.rect = new Rect(0f, Mathf.Lerp(0.5f, 0f, Time.deltaTime), 1f, 1f);
		else if (dp == DimensionPreferance.D2)
			dimensionTwoCamera.rect = new Rect (0f, 0f, 1f, Mathf.Lerp(0.5f, 1f, Time.deltaTime));
		else if (dp == DimensionPreferance.Neither){
			dimensionOneCamera.rect = new Rect(0f, Mathf.Lerp(0f, 0.5f, Time.deltaTime), 1f, 1f);
			dimensionTwoCamera.rect = new Rect(0f, 0f, 1f, Mathf.Lerp(1f, 0.5f, Time.deltaTime));
		}
	}

}

public enum DimensionPreferance {
	D1,
	D2,
	Neither
}