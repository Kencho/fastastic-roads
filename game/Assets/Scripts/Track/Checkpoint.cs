using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    /* Controlador de los checkpoints. */
    private TrackCheckpoints trackCheckpoints;

    /* Vehículo conductor, o sease, aquel que manejamos. */
    GameObject driver;

    /* Array de checkpoints para guardar el checkpoint anterior al indicado. */
    public Checkpoint[] PrevCheckpoints;

    private void OnTriggerEnter(Collider collider)
    {
        driver = GameObject.FindGameObjectWithTag("Player");

        if (driver.CompareTag(collider.gameObject.transform.parent.gameObject.tag))
        {
            collider.gameObject.SendMessageUpwards("CrossCheckpoint", this);
        }
    }

    // Lista de checkpoints anteriores permitidos (ej.: tenemos el 0, 1, 2: hay una bifurcación (3a y 3b), luego 4 y otra vez al 0, comprobar como un grafo)
    // 

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints;
    }

    public bool IsPreviousCheckpoint(Checkpoint anotherCheckpoint)
    {
        foreach (Checkpoint prevCheckpoint in PrevCheckpoints)
        {
            if (anotherCheckpoint == prevCheckpoint)
            {
                return true;
            }
        }

        return false;
    }
}
