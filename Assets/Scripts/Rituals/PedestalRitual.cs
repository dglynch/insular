using UnityEngine;
using System.Collections;
using System;

public class PedestalRitual : MonoBehaviour {

    public GameObject Portal;

    private int matchCount = 0;
    private int winningMatchCount = 3;

    void Start() {
        Portal.SetActive(false);
    }

    public void AddMatch() {
        matchCount++;

        if (matchCount >= winningMatchCount) {
            RitualComplete();
        }
    }

    public void RemoveMatch() {
        matchCount--;
        // Prevent negative numbers
        matchCount = Math.Max(matchCount, 0);
    }

    private void RitualComplete() {
        Portal.SetActive(true);
    }
}
