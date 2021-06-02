using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    /* Vuelta en la que nos hallamos. */
    public GameObject CurrentLap;

    /* Objetivo de vueltas final. */
    public GameObject FinalLap;

    /* Gameobject correspondiente al vehículo conductor. */
    private GameObject driver;

    /* Contador de vueltas. */
    private int lapCounter = 0;

    /* Booleano que indica el inicio de carrera. */
    public static bool finished = false;

    void Start()
    {
        finished = false;
    }

    void Awake()
    {
        FinalLap.GetComponent<Text>().text = "/" + RaceController.LapNumber;
    }

    public void UpdateLapCounter(int KartLap)
    {
        if (!finished)
        {
            CurrentLap.GetComponent<Text>().text = KartLap.ToString();
        }

        if (!finished && KartLap == RaceController.LapNumber + 1)
        {
            finished = true;
            CurrentLap.GetComponent<Text>().text = "";
            FinalLap.GetComponent<Text>().text = "FIN";
        }
    }
}
