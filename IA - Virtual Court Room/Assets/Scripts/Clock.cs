using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    private int hour;
    private int minute;
    private int second;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        second = System.DateTime.Now.Second;

        float hourRotation = (hour % 12) * 30f; // 30 Grad pro Stunde
        float minuteRotation = minute * 6f; //6 Grad pro Minute
        float secondRotation = second * 6f; //6 Grad pro Sekunde

        hourHand.localRotation = Quaternion.Euler(0f, hourRotation, 0f);
        minuteHand.localRotation = Quaternion.Euler(0f, minuteRotation, 0f);
        secondHand.localRotation = Quaternion.Euler(0f, secondRotation, 0f);
    }
}
