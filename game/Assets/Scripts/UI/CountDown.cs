using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KartGame.KartSystems;

public class CountDown : MonoBehaviour
{
    private float currentTime = 4f;
    public static bool stop = false;
    public GameObject CountdownDisplay;
    public ArcadeKart Driver;

    public AudioSource ReadySound;
    public AudioSource GoSound;

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
