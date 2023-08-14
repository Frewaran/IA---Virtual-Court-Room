using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRecorder : MonoBehaviour
{
    AudioSource audioSource;
    private string microphoneName = Microphone.devices[0];
    bool recorded = false;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        //foreach(var mic in Microphone.devices) {
          //  Debug.Log(mic);
        //}
    }

    public void StartRecordingAudio() {
        audioSource.clip = Microphone.Start(microphoneName, true, 5, 44100);
        audioSource.Play();
        Debug.Log("Start");
    }
    /*
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
    */
}