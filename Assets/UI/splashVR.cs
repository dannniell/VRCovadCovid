using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashVR : MonoBehaviour
{
	void Start()
	{
		Screen.autorotateToPortrait = true;
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		StartCoroutine(Example());
		
	}

	IEnumerator Example()
	{
		yield return new WaitForSeconds(2);
		Application.LoadLevel("menuVR");
	}

}