using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;

public class switchVR : MonoBehaviour
{

	void Start()
	{
		StartCoroutine(SwitchToVR());
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Android close icon or back button tapped.
            Application.LoadLevel("menuVR");
        }
    }

	IEnumerator SwitchToVR() {
		// Device names are lowercase, as returned by `XRSettings.supportedDevices`.
		string desiredDevice = "cardboard"; // Or "cardboard".

		// Some VR Devices do not support reloading when already active, see
		// https://docs.unity3d.com/ScriptReference/XR.XRSettings.LoadDeviceByName.html
	
		XRSettings.LoadDeviceByName(desiredDevice);

		// Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
		yield return null;

		// Now it's ok to enable VR mode.
		XRSettings.enabled = true;
	}
}