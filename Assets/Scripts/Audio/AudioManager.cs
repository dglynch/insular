using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class AudioManager : MonoBehaviour {

    public List<AudioClip> AudioClips;
    public TimeController TimeController;

    protected Dictionary<string, AudioClip> nameToAudioClip;
    protected AudioSource audioSource;

    void Start() {
        nameToAudioClip = AudioClips.ToDictionary(i => i.name, i => i);
        audioSource = this.gameObject.GetComponent<AudioSource>();

        SetUpEvents();
    }

    virtual protected void SetUpEvents() {
        // Override this in child AudioManager classes to set up events in the TimeController.
    }
}
