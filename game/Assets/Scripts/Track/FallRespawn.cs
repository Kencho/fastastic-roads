using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{   
    
    void OnTriggerEnter(Collider collider)
    {
        collider.SendMessageUpwards("Respawn");
    }

    void OnCollisionEnter(Collision collision)
    {
        collision.collider.SendMessageUpwards("Respawn");
    }
}
