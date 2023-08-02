using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRecorder : MonoBehaviour
{
    public void StartRecordingAudio() {
        AudioSource audioSource = GetComponent<AudioSource>();
        string microphoneName = Microphone.devices[2];
        audioSource.clip = Microphone.Start(microphoneName, true, 5, 44100);
        audioSource.Play();
    }
    public void StopRecordingAudio() {

    }
}