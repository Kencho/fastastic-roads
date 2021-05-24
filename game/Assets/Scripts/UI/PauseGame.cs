using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    /* Indica si el juego está pausado o no. */
    public bool gamePaused = false;

    /* Indica si el juego está finalizado o no. */
    public static bool gameFinished = false;

    /* Menú de pausa. */
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            } else
            {
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
    }

    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        gameFinished = true;
        SceneManager.LoadScene(0);
    }
}
