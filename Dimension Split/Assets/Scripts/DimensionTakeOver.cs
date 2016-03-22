using UnityEngine;
using System.Collections;

public class DimensionTakeOver : MonoBehaviour {

	public Camera dimensionOneCamera;
	public Camera dimensionTwoCamera;

	public float cameraSlowerMultipler;

	public DimensionPreferance dp = DimensionPreferance.Neither;

	void Update() {

		if (Input.GetKeyDown(KeyCode.O)){
			dp = DimensionPreferance.D1;
			StartCoroutine("CameraMerge");
		} else if (Input.GetKeyDown(KeyCode.P)){
			dp = DimensionPreferance.D2;
			StartCoroutine("CameraMerge");
		} else if (Input.GetKeyDown(KeyCode.N)){
			dp = DimensionPreferance.Neither;
			StartCoroutine("CameraMerge");
		}



	}

	IEnumerator CameraMerge () {
		if (dp == DimensionPreferance.D1){
			dimensionOneCamera.rect = new Rect (0f, Mathf.Lerp (0.5f, 0f, Time.time/cameraSlowerMultipler), 1f, 1f);
			dimensionTwoCamera.rect = new Rect (0f, 0f, 1f, Mathf.Lerp (0.5f, 0f, Time.time/cameraSlowerMultipler));
			yield return null;
		} else if (dp == DimensionPreferance.D2){
			dimensionOneCamera.rect = new Rect (0f, Mathf.Lerp (0.5f, 1f, Time.time/cameraSlowerMultipler), 1f, 1f);
			dimensionTwoCamera.rect = new Rect (0f, 0f, 1f, Mathf.Lerp (0.5f, 1f, Time.time/cameraSlowerMultipler));
			yield return null;
		} else if (dp == DimensionPreferance.Neither) {
			dimensionOneCamera.rect = new Rect (0f, Mathf.Lerp (0f, 0.5f, Time.time/cameraSlowerMultipler), 1f, 1f);
			dimensionTwoCamera.rect = new Rect (0f, 0f, 1f, Mathf.Lerp (1f, 0.5f, Time.time/cameraSlowerMultipler));
			yield return null;
		}
	}

}

public enum DimensionPreferance {
	D1,
	D2,
	Neither
}