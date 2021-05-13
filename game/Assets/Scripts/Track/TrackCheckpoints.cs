using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    /* Lista de puntos de control en el circuito. */
    private List<Checkpoint> checkpointList;

    /* Siguiente punto de control por el que se tiene que pasar. */
    private int nextCheckpoint = 0;

    /* Variable de acceso global que indica el siguiente punto de control por el que se tiene que pasar. */
    public static int nextCP;

    /* Veh�culo conductor, o sease, aquel que manejamos. */
    GameObject driver;

    /* Posici�n del veh�culo que manejamos. */
    public static Vector3 driverPosition = new Vector3(-49.8921585f, -17.0823498f, 106.940109f);

    /* Rotaci�n del veh�culo que manejamos. */
    public static Quaternion driverRotation = Quaternion.Euler(0, 0.28f, 0);

    /* Checkpoint �ltimo por el que hemos pasado antes de caer al vac�o con el veh�culo. */
    public static Checkpoint checkpointFall;

    private void Awake()
    {
        Transform checkpoints = transform.Find("Checkpoints");

        checkpointList = new List<Checkpoint>();

        foreach (Transform checkpointTransform in checkpoints)
        {
            Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>();
            
            checkpoint.SetTrackCheckpoints(this);
            
            checkpointList.Add(checkpoint);
        }

        nextCheckpoint = 0;
    }

    public void DriverThroughCheckpoint(Checkpoint checkpoint)
    {
        checkpointFall = checkpoint;
        nextCP = nextCheckpoint;

        if (checkpointList.IndexOf(checkpoint) == nextCheckpoint)
        {

            driverPosition = checkpointList[nextCheckpoint].gameObject.transform.position;
            driverRotation = checkpointList[nextCheckpoint].gameObject.transform.rotation;
            nextCheckpoint = (nextCheckpoint + 1) % checkpointList.Count;
            Debug.Log("�Correcto!");
        } else
        {
            Debug.Log("�Por aqu� no!");
        }
    }
}
