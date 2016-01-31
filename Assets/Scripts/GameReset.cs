using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameReset : MonoBehaviour {

    public TimeController TimeController;
    private object gameResetScript;

    void Start() {
        // Dying after new day
        TimeController.RegisterSubscription(
            new Func<bool>(() => TimeController.isTimeLaterThan(24, 0)),
            new Action(() => Reset())
        );
    }

    public void Reset() {
        SceneManager.LoadScene("World");
    }
}
