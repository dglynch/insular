using UnityEngine;
using System.Collections;

public class RegisterTrigger : MonoBehaviour {

    public TriggerQueue triggerQueue;

    // These prevent simultaneous triggers
    private double triggerTime = 0;
    private double invulnerabilityTime = 0.1;

    void OnTriggerEnter(Collider other) {
        if (Time.time - invulnerabilityTime > triggerTime) {
            Debug.Log(string.Format("{0}: TreeWalking trigger hit", Time.time));
            triggerQueue.AddToQueue(this.gameObject, other);
            triggerTime = Time.time;
        }
    }
}
