using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CountdownText : MonoBehaviour {

	public delegate void CountdownFinished();
	public static event CountdownFinished OnCountdownFinished;


	Text countdown;

	void OnEnable(){
		countdown = GetComponent<Text>();
		countdown.text = "3";
		StartCoroutine ("Countdown");
	
	
	}

	IEnumerator Countdown(){
		int count = 3;
		for (int i = 0; i < 3; i++) {
			countdown.text = (3 - i).ToString();
			yield return new WaitForSeconds (1);
			count -= 1;
		
		}
		if(count<=0)
			OnCountdownFinished?.Invoke();
	}
}
