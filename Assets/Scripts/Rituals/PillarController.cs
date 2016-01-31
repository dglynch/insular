using UnityEngine;
using System.Collections;

public class PillarController : MonoBehaviour {

    public PillarTrioController TrioController;

    public string PillarId;

    public GameObject Light;

    private bool active = false;

    private bool resetting = false;

    // Use this for initialization
    void Start() {
        Light.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (TrioController.puzzleFailed && resetting) {
            //Remove glow
            Debug.Log("Deactivate log");
            Light.SetActive(false);
            resetting = false;
        }
    }

    void OnTriggerEnter(Collider col) {
        Debug.Log("Pillar trigger [" + col.gameObject.name + "]");
        if (col.gameObject.name == "FPSController" && !active) {
            Debug.Log("Pillar [" + PillarId + "] hit");
            if (TrioController.PillarHit(PillarId)) {
                //Play sound
                //Glow
                Light.SetActive(true);
                active = true;
            }
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.name == "FPSController" && active) {
            Debug.Log("Pillar [" + PillarId + "] resetting");
            active = false;
            resetting = true;
        }
    }
}
