using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{   
    /* Veh�culo conductor, o sease, aquel que manejamos. */
    GameObject driver;

    void OnTriggerEnter(Collider collider)
    {
        driver = collider.gameObject.transform.parent.gameObject;

        if (driver.CompareTag("Player"))
        {
            driver.transform.position = TrackCheckpoints.checkpointFall.transform.position;
            driver.transform.rotation = TrackCheckpoints.checkpointFall.transform.rotation;
        }
    }
}
