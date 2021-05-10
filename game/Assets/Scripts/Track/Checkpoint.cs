using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private TrackCheckpoints trackCheckpoints;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.transform.parent.gameObject.tag == "Player")
            trackCheckpoints.DriverThroughCheckpoint(this);
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints;
    }
}
