using UnityEngine;
using System.Collections;
using System;

public class Ambience : AudioManager {

    protected override void SetUpEvents() {
        TimeController.RegisterSubscription(
            new Func<bool>(() => TimeController.isTimeLaterThan(18, 0)),
            new Action(() => {
                audioSource.Stop();
                audioSource.clip = nameToAudioClip["Ambience - Night"];
                audioSource.Play();
            }
        ));
    }
}
