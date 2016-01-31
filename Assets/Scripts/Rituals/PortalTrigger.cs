using UnityEngine;
using System.Collections;

public class PortalTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {
        Application.Quit();
    }
}
