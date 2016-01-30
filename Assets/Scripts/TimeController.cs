using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {
    
    private double secondOfDay = 21600;

    private bool paused = false;

    /// <summary>
    /// Hour portion of time of day. Will be 0-23.
    /// </summary>
    public int hour {
        get {
            return (int)(secondOfDay / 3600) % 24;
        }
    }

    /// <summary>
    /// Minute portion of time of day. Will be 0-59.
    /// </summary>
    public int minute {
        get {
            return (int)(secondOfDay / 60) % 60;
        }
    }

    public int speed = 60;

    void FixedUpdate() {
        var timeSinceLast = Time.fixedDeltaTime;
        
        UpdateTime(timeSinceLast);

        NewTimeEvents();
    }

    void OnGUI() {
        GUILayout.Label(string.Format("{0:00}:{1:00} {2}", FormattedHour(), minute, AmPmString()));
    }

    public float GetFractionalTimeAfterDawn() {
        return (float)(secondOfDay - (6 * 60 * 60)) / (float) (24 * 60 * 60);
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
        if (isTimeLaterThan(24, 0)) {
            // You've reached a new day and you died.
        }
    }

    private bool isTimeLaterThan(int hour, int minute) {
        return hour >= this.hour && minute >= this.minute;
    }

    // Converts the 12 hour time to 12-hour time.
    private int FormattedHour() {
        var returnHour = ((hour - 1) % 12) + 1;
        return returnHour == 0 ? 12 : returnHour;
    }

    private string AmPmString() {
        return hour < 12 ? "AM" : "PM";
    }
}
