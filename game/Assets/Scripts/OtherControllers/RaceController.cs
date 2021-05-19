using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class RaceController : MonoBehaviour
{
    /* Array de transformaciones que definirán los puntos de salida. */
    public Transform[] StartPositions;

    /* Vehículo que conducimos en la escena. */
    public GameObject Driver;

    private GameObject DriverStop;

    /* Resto de vehículos de la escena. */
    public GameObject[] NPCDrivers = new GameObject[7];

    /* Posición en el eje X de los vehículos en su instanciación. */
    private float PosicionX = 0;

    /* Vehículo que conducimos en la escena para su reaparecimiento. */
    private GameObject driverRespawn;

    /* Número de vueltas a realizar en la contrarreloj. */
    public static int LapNumber = 4;

    /* Flag para frenar el cambio continuo del componente en el Update. */
    private bool flag = true;

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
        driverRespawn = GameObject.FindGameObjectWithTag("Player");

        if (!CountDown.stop && flag)
        {
            driverRespawn.transform.GetComponent<KeyboardInput>().Horizontal = "";
            driverRespawn.transform.GetComponent<KeyboardInput>().Vertical = "";

            flag = false;
        } else if (CountDown.stop && !flag)
        {
            driverRespawn.transform.GetComponent<KeyboardInput>().Horizontal = "Horizontal";
            driverRespawn.transform.GetComponent<KeyboardInput>().Vertical = "Vertical";

            flag = true;
        }

        if (CountDown.stop && Input.GetKeyDown(KeyCode.R))
        {
            driverRespawn.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            driverRespawn.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            driverRespawn.transform.position = TrackCheckpoints.driverPosition;
            driverRespawn.transform.rotation = TrackCheckpoints.driverRotation;
        }
    }
}