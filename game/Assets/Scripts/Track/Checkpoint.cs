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

    private void OnTriggerEnter(Collider collider)
    {
        driver = collider.gameObject.transform.parent.gameObject;

        if (driver.CompareTag("Player"))
        {
            trackCheckpoints.DriverThroughCheckpoint(this);
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints;
    }
}
