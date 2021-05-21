using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KartGame.KartSystems;

public class RaceController : MonoBehaviour
{
    /* Array de transformaciones que definirán los puntos de salida. */
    public Transform[] StartPositions;

    /* Vehículo que conducimos en la escena. */
    public GameObject Driver;

    /* Resto de vehículos de la escena. */
    public GameObject[] NPCDrivers = new GameObject[7];

    /* Posición en el eje X de los vehículos en su instanciación. */
    private float PosicionX = 0;

    /* Vehículo que conducimos en la escena para su reaparecimiento. */
    private GameObject DriverRespawn;

    /* Número de vueltas a realizar en la contrarreloj. */
    public static int LapNumber = 4;

    /* Flag para frenar el cambio continuo del componente en el Update. */
    private bool Flag = true;

    /* Tiempo de espera al finalizar la carrera para el cambio de escena. */
    private float WaitTime = 0;

    void Start()
    {
        if (StartPositions.Length != 0 && StartPositions[0] != null)
            Instantiate(Driver, new Vector3(PosicionX = StartPositions[0].position.x, StartPositions[0].position.y, StartPositions[0].position.z), Quaternion.Euler(StartPositions[0].eulerAngles.x, StartPositions[0].eulerAngles.y, StartPositions[0].eulerAngles.z));
        else
            Instantiate(Driver, new Vector3(PosicionX += 5, 0, 0), Quaternion.identity);

        for (int i = 0; i < NPCDrivers.Length; i++)
            if (StartPositions[i] != null)
                Instantiate(NPCDrivers[i], new Vector3(PosicionX = StartPositions[i+1].position.x, StartPositions[i+1].position.y, StartPositions[i+1].position.z), Quaternion.Euler(StartPositions[i+1].eulerAngles.x, StartPositions[i + 1].eulerAngles.y, StartPositions[i + 1].eulerAngles.z));
            else
                Instantiate(NPCDrivers[i], new Vector3(PosicionX += 5, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        DriverRespawn = GameObject.FindGameObjectWithTag("Player");

        if (!CountDown.stop && Flag)
        {
            Flag = false;
            DriverRespawn.transform.GetComponent<KeyboardInput>().Blocked = true;
        } else if (CountDown.stop && !Flag)
        {
            Flag = true;
            DriverRespawn.transform.GetComponent<KeyboardInput>().Blocked = false;
        }

        if (CountDown.stop && Input.GetButtonDown("Respawn"))
        {
            DriverRespawn.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            DriverRespawn.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            DriverRespawn.transform.position = TrackCheckpoints.driverPosition;
            DriverRespawn.transform.rotation = TrackCheckpoints.driverRotation;
        }

        if (LapCounter.finished)
        {
            WaitTime += Time.deltaTime;
            DriverRespawn.transform.GetComponent<KeyboardInput>().Blocked = true;
        }

        if ((int)WaitTime == 4) SceneManager.LoadScene(4);
    }
}