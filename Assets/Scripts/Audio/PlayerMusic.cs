using UnityEngine;
using System.Collections;
using System;

public class PlayerMusic : AudioManager {

    protected override void SetUpEvents() {
        TimeController.RegisterSubscription(
            new Func<bool>(() => TimeController.isTimeLaterThan(18, 0)),
            new Action(() => {
                // Set this up when the proper music is linked
                //audioSource.Stop();
                //audioSource.clip = nameToAudioClip["Ambience - Lake - Waves"];
                //audioSource.Play();
            }
        ));
    }
}
