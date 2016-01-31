using UnityEngine;
using System.Collections;

public class AltarController : MonoBehaviour {

    private int ballCount;

    public GameObject TargetObject;

    // Use this for initialization
	void Start () {
        ballCount = 0;
        TargetObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        if (ballCount >= 3 ) {
            Debug.Log("More than one ball");
            TargetObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider col) {
        Debug.Log("Collision Enter. Tag = " + col.gameObject.tag);
        if (col.gameObject.tag == "balls") {
            Debug.Log("Added ball");
            ballCount++;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "balls") {
            ballCount--;
            if (ballCount < 0) {
                ballCount = 0;
            }
        }
    }

}
