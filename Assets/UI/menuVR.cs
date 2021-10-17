using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;

public class menuVR : MonoBehaviour
{

	public void GoToVR()
	{
		Application.LoadLevel("cobaRoom");
	
	}

	void Start()
	{
		Screen.orientation = ScreenOrientation.Portrait;
		Screen.autorotateToPortrait = true;
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		StartCoroutine(SwitchTo2D());
	}

	void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Android close icon or back button tapped.
            Application.Quit();
        }
    }

	IEnumerator SwitchTo2D() {
		// Empty string loads the "None" device.
		XRSettings.LoadDeviceByName("");

		// Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
		yield return null;

		// Not needed, since loading the None (`""`) device takes care of this.
		// XRSettings.enabled = false;

		// Restore 2D camera settings.
		ResetCameras();
		}

		// Resets camera transform and settings on all enabled eye cameras.
		void ResetCameras() {
		// Camera looping logic copied from GvrEditorEmulator.cs
		for (int i = 0; i < Camera.allCameras.Length; i++) {
			Camera cam = Camera.allCameras[i];
			if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None) {

			// Reset local position.
			// Only required if you change the camera's local position while in 2D mode.
			cam.transform.localPosition = Vector3.zero;

			// Reset local rotation.
			// Only required if you change the camera's local rotation while in 2D mode.
			cam.transform.localRotation = Quaternion.identity;

			// No longer needed, see issue github.com/googlevr/gvr-unity-sdk/issues/628.
			// cam.ResetAspect();

			// No need to reset `fieldOfView`, since it's reset automatically.
			}
		}
	}
}