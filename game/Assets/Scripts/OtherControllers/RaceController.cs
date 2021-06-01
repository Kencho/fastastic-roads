using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KartGame.KartSystems;

public class RaceController : MonoBehaviour
{
    /* Array de transformaciones que definir�n los puntos de salida. */
    public Transform[] StartPositions;

    /* Veh�culo que conducimos en la escena. */
    public GameObject Driver;

    /* Resto de veh�culos de la escena. */
    public GameObject[] NPCDrivers = new GameObject[7];

    /* Posici�n en el eje X de los veh�culos en su instanciaci�n. */
    private float PosicionX;

    /* */
    public static Vector3 initPosition;

    /* */
    public static Quaternion initRotation;

    /* Veh�culo que conducimos en la escena para su reaparecimiento. */
    private GameObject DriverRespawn;

    /* N�mero de vueltas a realizar en la contrarreloj. */
    public static int LapNumber = 4;

    /* Flag para frenar el cambio continuo del componente en el Update. */
    private bool Flag = true;

    /* Tiempo de espera al finalizar la carrera para el cambio de escena. */
    private float WaitTime;

    /*  */
    public Checkpoint FinishLine;

    public int raceId = 0;

    void Start()
    {
        GameObject vehicle;
        WaitTime = 0;

        if (StartPositions.Length != 0 && StartPositions[0] != null)
            vehicle = Instantiate(Driver, new Vector3(PosicionX = StartPositions[0].position.x, StartPositions[0].position.y, StartPositions[0].position.z), Quaternion.Euler(StartPositions[0].eulerAngles.x, StartPositions[0].eulerAngles.y, StartPositions[0].eulerAngles.z));
        else
            vehicle = Instantiate(Driver, new Vector3(PosicionX += 5, 0, 0), Quaternion.identity);

        vehicle.SendMessage("SetLastCheckpoint", FinishLine);
        vehicle.SendMessage("SetRaceId", raceId);
        Debug.Log("El id de veh�culo conductor es: " + raceId);
        raceId++;
        initPosition = vehicle.transform.position;
        initRotation = vehicle.transform.rotation;

        for (int i = 0; i < NPCDrivers.Length; i++)
        {
            if (StartPositions[i] != null)
                vehicle = Instantiate(NPCDrivers[i], new Vector3(PosicionX = StartPositions[i + 1].position.x, StartPositions[i + 1].position.y, StartPositions[i + 1].position.z), Quaternion.Euler(StartPositions[i + 1].eulerAngles.x, StartPositions[i + 1].eulerAngles.y, StartPositions[i + 1].eulerAngles.z));
            else
                vehicle = Instantiate(NPCDrivers[i], new Vector3(PosicionX += 5, 0, 0), Quaternion.identity);
            
            vehicle.SendMessage("SetLastCheckpoint", FinishLine);
            vehicle.SendMessage("SetRaceId", raceId);
            Debug.Log("El id del veh�culo NPC " + i + " es: " + raceId);
            raceId++;
            
        }
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