using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specialText : MonoBehaviour
{
    public Text text;
    public bool collided;

    private void OnEnable()
    {
        Score.OnScoreCountingStarted += startText;
        Score.OnHalfway += halfwayText;
        PlayerCollision.OnPlayerCollided += collisionText;
        Score.OnComplete += completeText;
    }

    private void OnDisable()
    {
        Score.OnScoreCountingStarted -= startText;
        Score.OnHalfway -= halfwayText;
        PlayerCollision.OnPlayerCollided -= collisionText;
        Score.OnComplete -= completeText;
    }

    public void startText()
    {
        text.text = "Here we go!";
    }

    public void halfwayText()
    {
        if(!collided)
        {
            text.text = "Almost there!";
        }
    }

    public void collisionText()
    {
        text.text = "You absolute fool.";
    }

    public void completeText()
    {
        text.text = "You did it!";
    }
}
