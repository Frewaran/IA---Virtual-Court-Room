using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRecorder : MonoBehaviour
{
    AudioSource audioSource;
    private string microphoneName = "Auna Mic CM900";
    bool recorded = false;

    private void Awake() {

    }

    public void StartRecordingAudio() {
        audioSource.clip = Microphone.Start(microphoneName, true, 5, 44100);
        Debug.Log("Start");
    }
    public void StopRecordingAudio() {
        Microphone.End(microphoneName);
        recorded = true;
        Debug.Log("Stop");
    }

    private void Update() {
        if (recorded) {
            audioSource.Play();

            Debug.Log("Recorded");
        }
    }
}