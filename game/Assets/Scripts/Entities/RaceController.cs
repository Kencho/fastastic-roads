using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    /* Array de transformaciones que definir�n los puntos de salida. */
    public Transform[] StartPositions;

    /* Veh�culo del juego que conducimos. */
    public GameObject Driver;

    /* Resto de veh�culos de la escena. */
    public GameObject[] NPCDrivers = new GameObject[7];

    /* Posici�n en el eje X de los veh�culos en su instanciaci�n. */
    private float PosicionX = 0;

    void Start()
    {
        if(StartPositions.Length != 0 && StartPositions[0] != null)
            Instantiate(Driver, new Vector3(PosicionX = StartPositions[0].position.x, StartPositions[0].position.y, StartPositions[0].position.z), Quaternion.identity);
        else
            Instantiate(Driver, new Vector3(PosicionX += 5, 0, 0), Quaternion.identity);        

        for (int i = 0; i < NPCDrivers.Length; i++)
            if (StartPositions[i] != null)
                Instantiate(NPCDrivers[i], new Vector3(PosicionX = StartPositions[i+1].position.x, StartPositions[i+1].position.y, StartPositions[i+1].position.z), Quaternion.identity);
            else
                Instantiate(NPCDrivers[i], new Vector3(PosicionX += 5, 0, 0), Quaternion.identity);
    }
}
