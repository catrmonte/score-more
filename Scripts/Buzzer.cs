using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzer : MonoBehaviour
{
    // Will need to be attached to a GameObject 

    private void OnEnable() // subscribe to these events
    {
        Timer.OnTimerStarted += PlayStartBuzzer;
        Timer.OnTimerEnded += PlayEndBuzzer;
    }

    private void OnDisable()
    {
        Timer.OnTimerStarted -= PlayStartBuzzer;
        Timer.OnTimerEnded -= PlayEndBuzzer;  // We do this to unsubscribe from these functions 
    }

    public void PlayStartBuzzer()
    {
        Debug.Log("[Buzzer] : Play start buzzer!");
    }

    public void PlayEndBuzzer()
    {
        Debug.Log("[Buzzer] : Play end buzzer!");
    }
}
