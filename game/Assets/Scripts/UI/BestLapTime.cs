using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KartGame.KartSystems;

/// <summary>
/// Get and update the best lap time in a race.
/// 
/// @author Alejandro Goicoechea Román
/// </summary>
public class BestLapTime : MonoBehaviour
{
    public GameObject BestMinuteDisplay;
    public GameObject BestSecondDisplay;
    public GameObject BestMilliDisplay;

    private int BestMin = 9999;

    private int BestSec = 9999;

    private float BestMilli = 9999;

    public void Lap(ArcadeKart arcadeKart)
    {
        if (LapTime.MinuteCount < BestMin || LapTime.MinuteCount == BestMin && LapTime.SecondCount < BestSec || LapTime.MinuteCount == BestMin && LapTime.SecondCount == BestSec && int.Parse(LapTime.MilliCount.ToString("F0")) < BestMilli)
        {
            BestMin = LapTime.MinuteCount;
            BestSec = LapTime.SecondCount;
            BestMilli = LapTime.MilliCount;

            BestMilliDisplay.GetComponent<Text>().text = "" + LapTime.MilliCount.ToString("F0");

            if (LapTime.SecondCount <= 9)
            {
                BestSecondDisplay.GetComponent<Text>().text = "0" + LapTime.SecondCount + ".";
            }
            else
            {
                BestSecondDisplay.GetComponent<Text>().text = "" + LapTime.SecondCount + ".";
            }

            if (LapTime.MinuteCount <= 9)
            {
                BestMinuteDisplay.GetComponent<Text>().text = "0" + LapTime.MinuteCount + ":";
            }
            else
            {
                BestMinuteDisplay.GetComponent<Text>().text = "" + LapTime.MinuteCount + ":";
            }
        }

        LapTime.MinuteCount = 0;
        LapTime.SecondCount = 0;
        LapTime.MilliCount = 0;
    }
}
