using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    public GameObject CurrentLap;

    public GameObject FinalLap;

    /* Contador de vueltas. */
    private int lapCounter = 0;

    /* Booleano que indica el inicio de carrera. */
    private bool finished = false;

    void Awake()
    {
        FinalLap.GetComponent<Text>().text = "/" + RaceController.LapNumber;
    }

    void OnTriggerEnter()
    {
        if (!finished && TrackCheckpoints.nextCP == 0)
        {
            lapCounter++;
            CurrentLap.GetComponent<Text>().text = lapCounter.ToString();
        }

        if(!finished && lapCounter == RaceController.LapNumber + 1)
        {
            finished = true;
            CurrentLap.GetComponent<Text>().text = "";
            FinalLap.GetComponent<Text>().text = "FIN";
        }
    }
}
