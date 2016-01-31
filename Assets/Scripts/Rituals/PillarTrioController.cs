using UnityEngine;
using System.Collections;

public class PillarTrioController : MonoBehaviour {

    private string code;

    private bool codeComplete;

    public GameObject TargetCube;

    public GameObject[] Pillars;

    public bool puzzleFailed;

    // Use this for initialization
    void Start () {
        code = "";
        codeComplete = false;
        TargetCube.SetActive(false);
        puzzleFailed = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool PillarHit(string pillarId) {
        Debug.Log("Pillar [" + pillarId + "] hit");
        puzzleFailed = false;
        if (!codeComplete) {
            code = code + pillarId;
            if (code.Length < 3) {
                Debug.Log("code [" + code + "]");
                return true;
            } else if (code == "bac") {
                Debug.Log("code [" + code + "] complete");
                TargetCube.SetActive(true);
                return true;
            } else {
                code = "";
                puzzleFailed = true;
                //Play failed sound
                Debug.Log("Code failed");
                return false;
            }
        } else {
            return false;
        }
    }
}
