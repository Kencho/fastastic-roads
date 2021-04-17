using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    /* Array de transformaciones que definirán los puntos de salida. */
    public Transform[] StartPositions;

    /* Vehículo del juego que conducimos. */
    public GameObject Driver;

    /* Resto de vehículos de la escena. */
    public GameObject[] NPCDrivers = new GameObject[7];

    /* Posición en el eje X de los vehículos en su instanciación. */
    private int PosicionX = 0;

    void Start()
    {
        Instantiate(Driver, new Vector3(PosicionX += 4, 0, 0), Quaternion.identity);
        for (int i = 0; i < NPCDrivers.Length; i++)
            Instantiate(NPCDrivers[i], new Vector3(PosicionX += 4, 0, 0), Quaternion.identity);
    }
}
