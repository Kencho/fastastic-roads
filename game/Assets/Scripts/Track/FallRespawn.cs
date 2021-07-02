using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Al entrar en contacto con el trigger, el objeto se recoloca en el último
/// punto de control.
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
