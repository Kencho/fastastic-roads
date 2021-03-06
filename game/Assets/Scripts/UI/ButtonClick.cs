using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Associates with each button in the menus the load of the scene 
/// indicated by an identifier. 
/// 
/// @author Alejandro Goicoechea Román
/// </summary>
public class ButtonClick : MonoBehaviour
{
    // Main Menu Buttons

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(5);
    }

    public void Credits()
    {
        SceneManager.LoadScene(6);
    }

    public void Exit()
    {
        Application.Quit();
    }

    // Mode Selector Buttons

    public void TimeTrial()
    {
        SceneManager.LoadScene(2);
    }

    public void Race()
    {
        // TODO
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Character Selector Buttons

    public void AmeliaEarhart()
    {
        // ¿Guardar personaje en una variable?
        SceneManager.LoadScene(3);
    }

    public void PilarCareaga()
    {
        // ¿Guardar personaje en una variable?
        SceneManager.LoadScene(3);
    }

    public void BackToModeSelector()
    {
        SceneManager.LoadScene(1);
    }

    // Track Selector Buttons

    public void CircuitOne()
    {
        // ¿Guardar circuito en una variable?
        SceneManager.LoadScene(7);
    }

    public void CircuitTwo()
    {
        // ¿Guardar circuito en una variable?
        SceneManager.LoadScene(7);
    }

    public void BackToCharacterSelector()
    {
        SceneManager.LoadScene(2);
    }
}
