using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keluar : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Android close icon or back button tapped.
            Application.LoadLevel("menuVR");
        }
    }
}
