using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using KartGame.KartSystems;

[RequireComponent(typeof(LapCounter))]
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

    /* Posici�n de inicio de partida del veh�culo. */
    public static Vector3 initPosition;

    /* Rotaci�n de inicio de partida del veh�culo. */
    public static Quaternion initRotation;

    /* Veh�culo que conducimos en la escena para su reaparecimiento. */
    private GameObject DriverRespawn;

    /* N�mero de vueltas a realizar en la contrarreloj. */
    private static int lapNumber = 4;

    public static int LapNumber { get => lapNumber; set => lapNumber = value; }

    /* Flag para frenar el cambio continuo del componente en el Update. */
    private bool Flag = true;

    /* Tiempo de espera al finalizar la carrera para el cambio de escena. */
    private float WaitTime;

    /* Checkpoint correspondiente a la l�nea de meta. */
    public Checkpoint FinishLine;

    /* Identificador de corredor. */
    private int raceId = 0;

    /* Contiene el n�mero de vueltas dada por cada corredor. */
    private int[] racerLaps;

    /* N�mero de veh�culos total en la partida. */
    private int vehicleNumber = 1;

    /* Mejor tiempo en una vuelta. */
    public BestLapTime bestLapTime;

    void Start()
    {
        GameObject vehicle;
        WaitTime = 0;
        
        for (int i = 0; i < NPCDrivers.Length; i++) if (NPCDrivers[i] != null) vehicleNumber++;
        racerLaps = new int[vehicleNumber];

        if (StartPositions.Length != 0 && StartPositions[0] != null)
            vehicle = Instantiate(Driver, new Vector3(PosicionX = StartPositions[0].position.x, StartPositions[0].position.y, StartPositions[0].position.z), Quaternion.Euler(StartPositions[0].eulerAngles.x, StartPositions[0].eulerAngles.y, StartPositions[0].eulerAngles.z));
        else
            vehicle = Instantiate(Driver, new Vector3(PosicionX += 5, 0, 0), Quaternion.identity);

        vehicle.SendMessage("SetRaceController", this);
        vehicle.SendMessage("SetLastCheckpoint", FinishLine);
        vehicle.SendMessage("SetRaceId", raceId);
        racerLaps[raceId] = 1;
        raceId++;

        initPosition = vehicle.transform.position;
        initRotation = vehicle.transform.rotation;

        Debug.Log("El tama�o de NPCDrivers es de: " + NPCDrivers.Length);
        for (int i = 0; i < NPCDrivers.Length; i++)
        {
            if (NPCDrivers[i] != null)
            {
                if (StartPositions[i] != null)
                    vehicle = Instantiate(NPCDrivers[i], new Vector3(PosicionX = StartPositions[i + 1].position.x, StartPositions[i + 1].position.y, StartPositions[i + 1].position.z), Quaternion.Euler(StartPositions[i + 1].eulerAngles.x, StartPositions[i + 1].eulerAngles.y, StartPositions[i + 1].eulerAngles.z));
                else
                    vehicle = Instantiate(NPCDrivers[i], new Vector3(PosicionX += 5, 0, 0), Quaternion.identity);

                vehicle.SendMessage("SetRaceController", this);
                vehicle.SendMessage("SetLastCheckpoint", FinishLine);
                vehicle.SendMessage("SetRaceId", raceId);
                Debug.Log("El id del veh�culo NPC " + i + " es: " + raceId);
                racerLaps[raceId] = 1;
                raceId++;
            }
        }

        Debug.Log("RacerLaps tiene un tama�o de: " + vehicleNumber);
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

        if (LapCounter.finished)
        {
            WaitTime += Time.deltaTime;
            DriverRespawn.transform.GetComponent<KeyboardInput>().Blocked = true;
        }

        if ((int)WaitTime == 4) SceneManager.LoadScene(4);
    }

    public void CheckpointCrossed(ArcadeKart arcadeKart, Checkpoint checkpointCrossed)
    {
        if (checkpointCrossed == FinishLine)
        {
            AddLapToDriver(arcadeKart.GetRaceId());
            bestLapTime.Lap(arcadeKart);
            GetComponent<LapCounter>().UpdateLapCounter(racerLaps[arcadeKart.GetRaceId()]);
        }
    }

    private void AddLapToDriver(int RaceId)
    {
        racerLaps[RaceId]++;
    }

    public int GetLapFromDriver(int RaceId)
    {
        return racerLaps[RaceId];
    }
}