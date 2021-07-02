using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When interacting with the trigger, the object is respawned at the last control point. 
/// 
/// @author Alejandro Goicoechea Román
/// </summary>
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
