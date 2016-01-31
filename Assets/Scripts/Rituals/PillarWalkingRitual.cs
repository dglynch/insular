using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class PillarWalkingRitual : TriggerQueue {

    public GameObject RewardCube;

    void Start() {
        maxItemsInQueue = 7;
        RewardCube.SetActive(false);
    }

    protected override void Triggered() {
        var ids = triggerQueue.Select(i => Convert.ToInt32(i.name.Split('_').Last())).ToList();
        var id = ids.First();
        var ritualCompleted = true;

        for (var i = 0; i < maxItemsInQueue; i++, id = ((id + 1) % maxItemsInQueue)) {
            if (ids[i] != id) {
                ritualCompleted = false;
                break;
            }
        }

        if (ritualCompleted) {
            triggerQueue.Clear();
            Debug.Log(string.Format("{0}: PillarWalkingRitual complete", Time.time));
            RewardCube.SetActive(true);
        }
    }
}
