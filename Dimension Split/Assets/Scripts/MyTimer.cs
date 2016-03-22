using UnityEngine;
using System.Collections;

public class MyTimer: MonoBehaviour{

	public float time;
	public float maxTimer = 1f;

	bool timeOn;

	void Update() {

		if (timeOn)
			time += Time.deltaTime;

		if (time >= maxTimer){
			time = maxTimer;
			timeOn = false;
		}
	}

	public void StartTimer(){
		time = 0;
		timeOn = true;
	}

	public float GetTime(){
		return time;
	}

}
