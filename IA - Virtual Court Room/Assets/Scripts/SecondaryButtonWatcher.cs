using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;


[System.Serializable]
public class SecondaryButtonEvent : UnityEvent<bool> { }

public class SecondaryButtonWatcher : MonoBehaviour
{
    public SecondaryButtonEvent secondaryButtonPress;

    private bool lastButtonState = false;
    private List<UnityEngine.XR.InputDevice> allDevices;
    private List<UnityEngine.XR.InputDevice> devicesWithSecondaryButton;

    // Start is called before the first frame update
    void Start()
    {
        if(secondaryButtonPress == null)
        {
            secondaryButtonPress = new SecondaryButtonEvent();
        }

        allDevices = new List<UnityEngine.XR.InputDevice>();
        devicesWithSecondaryButton = new List<UnityEngine.XR.InputDevice>();
        InputTracking.nodeAdded += InputTracking_nodeAdded;
    }

    // check for new input devices when new XRNode is added
    private void InputTracking_nodeAdded(XRNodeState obj)
    {
        updateInputDevices();
    }

    // Update is called once per frame
    void Update()
    {
        bool tempState = false;
        bool invalidDeviceFound = false;
        foreach(var device in devicesWithSecondaryButton)
        {
            bool secondaryButtonState = false;
            tempState = device.isValid // the device is still valid
                        && device.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButtonState) // did get a value
                        && secondaryButtonState // the value we got
                        || tempState; // cumulative result from other controllers
            if (!device.isValid)
                invalidDeviceFound = true;

        }

        if(tempState != lastButtonState) // Button state changed since last frame
        {
            secondaryButtonPress.Invoke(tempState);
            lastButtonState = tempState;
        }

        if (invalidDeviceFound || devicesWithSecondaryButton.Count == 0) // refresh device lists
            updateInputDevices();
    }

    // find any devices supporting the desired feature usage
    void updateInputDevices()
    {
        devicesWithSecondaryButton.Clear();
        UnityEngine.XR.InputDevices.GetDevices(allDevices);
        bool discardedValue;
        foreach (var device in allDevices)
        {
            if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out discardedValue))
            {
                devicesWithSecondaryButton.Add(device); // Add any devices that have a secondary button.
            }
        }
    }
} // Informationen hier: https://docs.unity.cn/2019.2/Documentation/Manual/xr_input.html
