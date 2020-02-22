using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float m_Duration = 10f;
    private float m_Halftime;

    public delegate void TimerStarted();  // could sub TimerStarted for anything, just method signature
    public static event TimerStarted OnTimerStarted;

    public delegate void Halftime();
    public static event Halftime OnHalfTime;

    public delegate void TimerEnded();
    public static event TimerEnded OnTimerEnded;

    private IEnumerator m_Coroutine;

    IEnumerator Start()
    {
        m_Halftime = m_Duration / 2;

        if (OnTimerStarted != null)  // Check to see if there's actually listeners
        {
            OnTimerStarted();
        }

        yield return StartCoroutine(WaitAndPrint(1.0f)); // Start yields operation to called function with a wait time of 1f

        if (OnTimerEnded != null)
        {
            OnTimerEnded();
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (Time.time < m_Duration)
        {
            yield return new WaitForSeconds(waitTime);

            Debug.Log("Seconds: " + Mathf.Round(Time.time));

            if (Mathf.Round(Time.time) == Mathf.Round(m_Halftime))
            {
                if (OnHalfTime != null) // check to make sure it exists
                {
                    OnHalfTime();
                }
            }
        }


    }
}
