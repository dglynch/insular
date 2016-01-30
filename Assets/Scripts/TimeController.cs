using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {


    /// <summary>
    /// Hour portion of time of day. Will be 0-23.
    /// </summary>
    int hour = 6;

    /// <summary>
    /// Minute portion of time of day. Will be 0-59.
    /// </summary>
    int minute = 0;

    /// <summary>
    /// Number of minutes incremented when event triggers.
    /// </summary>
    int minuteIncrement = 1;

    /// <summary>
    /// Real time until event gets triggered that updates the time.
    /// </summary>
    double secondsUntilIncrement = 1.0;


    private double lastChange = 0.0;

    void Update() {
        if (Time.time - lastChange > secondsUntilIncrement) {
            UpdateTime();

            NewTimeEvents();

            lastChange = Time.time;
        }
    }

    void OnGUI() {
        GUILayout.Label(string.Format("{0:00}:{1:00} {2}", FormattedHour(), minute, AmPmString()));
    }

    public float GetFractionalTimeAfterDawn() {
        return ((hour - 6) * 60 + minute) / (float) (24 * 60);
    }

    // Some help from: http://forum.unity3d.com/threads/noob-question-help-with-in-game-clock.37668/
    private void UpdateTime() {
        minute += minuteIncrement;
        if (minute >= 60) {
            minute %= 60;
            hour++;
            hour = hour % 24;
        }
    }

    /// <summary>
    /// Time-specific events happen here.
    /// </summary>
    private void NewTimeEvents() {
        if (isTime(0, 0)) {
            // You've reached a new day and you died.
        }
    }

    private bool isTime(int hour, int minute) {
        return hour == this.hour && minute == this.minute;
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
