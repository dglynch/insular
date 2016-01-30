using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerQueue : MonoBehaviour {

    protected int maxItemsInQueue = 100;

    protected Queue<GameObject> triggerQueue = new Queue<GameObject>();

    public void AddToQueue(GameObject gameObject, Collider collider) {
        if (collider.gameObject.name == "FPSController") {
            triggerQueue.Enqueue(gameObject);
            if (triggerQueue.Count > maxItemsInQueue) {
                triggerQueue.Dequeue();
            }

            // Only trigger if there are enough items in the queue.
            if (triggerQueue.Count == maxItemsInQueue) {
                Triggered();
            }
        }
    }

    virtual protected void Triggered() {

    }
}
