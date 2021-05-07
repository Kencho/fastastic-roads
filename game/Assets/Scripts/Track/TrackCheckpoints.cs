using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    /* Lista de puntos de control en el circuito. */
    private List<Checkpoint> checkpointList;

    /* Siguiente punto de control por el que se tiene que pasar. */
    private int nextCheckpoint = 0;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointList = new List<Checkpoint>();

        foreach (Transform checkpointTransform in checkpointsTransform)
        {
            Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>();
            
            checkpoint.SetTrackCheckpoints(this);
            
            checkpointList.Add(checkpoint);
        }

        nextCheckpoint = 0;
    }

    public void DriverThroughCheckpoint(Checkpoint checkpoint)
    {
        if(checkpointList.IndexOf(checkpoint) == nextCheckpoint)
        {
            nextCheckpoint = (nextCheckpoint + 1) % checkpointList.Count;
            Debug.Log("¡Correcto!");
        } else
        {
            Debug.Log("¡Por aquí no!");
        }
    }
}
