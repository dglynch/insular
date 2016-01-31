using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class TimeController : MonoBehaviour {

    public GameReset gameResetScript;

    /// <summary>
    /// The clip source to change.
    /// </summary>
    public AudioSource audioSource;
    /// <summary>
    /// Clip that starts playing at night.
    /// </summary>
    public AudioClip nightClip;

    private bool dayMusic = true;

    private double secondOfDay = 21600;

    private bool paused = false;

    private List<Subscription> subscriptions = new List<Subscription>();

    /// <summary>
    /// Hour portion of time of day. Will be 0-23.
    /// </summary>
    public int hour {
        get {
            return (int) (secondOfDay / 3600) % 24;
        }
    }

    /// <summary>
    /// Minute portion of time of day. Will be 0-59.
    /// </summary>
    public int minute {
        get {
            return (int) (secondOfDay / 60) % 60;
        }
    }

    public int speed = 60;

    void Start() {
        // Change of music at 6pm
        RegisterSubscription(
            new Func<bool>(() => isTimeLaterThan(18, 0) && dayMusic),
            new Action(() => {
                dayMusic = false;
                audioSource.Stop();
                audioSource.clip = nightClip;
                audioSource.Play();
            }));

        // Dying after new day
        RegisterSubscription(
            new Func<bool>(() => isTimeLaterThan(24, 0)),
            new Action(() => gameResetScript.Reset())
            );
    }

    void FixedUpdate() {
        var timeSinceLast = Time.fixedDeltaTime;

        UpdateTime(timeSinceLast);

        NewTimeEvents();
    }

    void OnGUI() {
        GUILayout.Label(string.Format("{0:00}:{1:00} {2}", FormattedHour(), minute, AmPmString()));
    }

    public float GetFractionalTimeAfterDawn() {
        return (float) (secondOfDay - (6 * 60 * 60)) / (float) (24 * 60 * 60);
    }

    private void UpdateTime(double timeSinceLast) {
        if (!paused) {
            secondOfDay += timeSinceLast * speed;
        }
    }

    /// <summary>
    /// Time-specific events happen here.
    /// </summary>
    private void NewTimeEvents() {
        foreach (var subscription in subscriptions) {
            if (subscription.Condition()) {
                subscription.Action();
                subscription.Completed = true;
            }
        }
        subscriptions = subscriptions.Where(i => i.Completed == false).ToList();
    }

    public void RegisterSubscription(Func<bool> condition, Action action) {
        subscriptions.Add(
            new Subscription {
                Condition = condition,
                Action = action,
                Completed = false
            }   
        );
    }

    private bool isTimeLaterThan(int hour, int minute) {
        return secondOfDay > ((hour * 60 * 60) + (minute * 60));
    }

    // Converts the 12 hour time to 12-hour time.
    private int FormattedHour() {
        var returnHour = ((hour - 1) % 12) + 1;
        return returnHour == 0 ? 12 : returnHour;
    }

    private string AmPmString() {
        return hour < 12 ? "AM" : "PM";
    }

    public class Subscription {
        public Func<bool> Condition;
        public Action Action;
        public bool Completed;
    }
}
