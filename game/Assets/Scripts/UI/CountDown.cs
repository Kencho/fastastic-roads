using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KartGame.KartSystems;

/// <summary>
/// Realiza una cuenta atrás antes de comenzar la carrera.
/// 
/// @author Alejandro Goicoechea Román
/// </summary>
public class CountDown : MonoBehaviour
{
    private float currentTime = 3.9f;
    public static bool stop = false;
    public GameObject CountdownDisplay;
    public ArcadeKart Driver;

    public AudioSource ReadySound;
    public AudioSource GoSound;

    void Start()
    {
        stop = false;
    }

    void Update()
    {
        if (!stop)
        {
            currentTime -= Time.deltaTime;

            if ((int)currentTime == 0)
            {
                CountdownDisplay.GetComponent<Text>().text = "GO!";

                if (GoSound != null) GoSound.Play();
            }

            if ((int)currentTime > 0)
            {
                CountdownDisplay.GetComponent<Text>().text = ((int)currentTime).ToString("0");
                if (ReadySound != null) ReadySound.Play();
            }

            if (currentTime < 0 && (int)currentTime >= -2)
            {
                CountdownDisplay.GetComponent<Text>().text = "";
                stop = true;
            }
        }
    }
}
