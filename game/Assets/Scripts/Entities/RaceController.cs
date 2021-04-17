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
    private int PosicionX = 0;

    void Start()
    {
        Instantiate(Driver, new Vector3(PosicionX += 4, 0, 0), Quaternion.identity);
        for (int i = 0; i < NPCDrivers.Length; i++)
            Instantiate(NPCDrivers[i], new Vector3(PosicionX += 4, 0, 0), Quaternion.identity);
    }
}
