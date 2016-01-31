using UnityEngine;
using System.Collections;

public class PlayerDrownController : MonoBehaviour {

    public GameObject character;

    public GameReset gameResetScript;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (character.transform.position.y < 9) {
            gameResetScript.Reset();
        }
    }

}
