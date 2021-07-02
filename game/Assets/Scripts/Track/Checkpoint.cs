using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The object behaves like a checkpoint. 
/// 
/// @author Alejandro Goicoechea Román
/// </summary>
public class Checkpoint : MonoBehaviour
{

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
