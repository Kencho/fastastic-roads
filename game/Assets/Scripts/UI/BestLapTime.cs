using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestLapTime : MonoBehaviour
{
    public GameObject BestMinuteDisplay;
    public GameObject BestSecondDisplay;
    public GameObject BestMilliDisplay;

    private int BestMin = 9999;

    private int BestSec = 9999;

    private float BestMilli = 9999;

    /* Booleano que indica si el checkpoint de inicio por el que pasamos es al principio de la carrera. */
    private bool inicio = true;

    void Start()
    {
        inicio = true;
    }

    void OnTriggerEnter()
    {
        if (inicio == true) inicio = false;
        else
        {
            if(!inicio && TrackCheckpoints.nextCP == 0)
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
    }
}
