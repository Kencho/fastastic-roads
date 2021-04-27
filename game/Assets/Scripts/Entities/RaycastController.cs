using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    /* Lista con las ruedas del vehículo. */
    public Transform[] Wheels = new Transform[4];

    /* Distancia de Raycast para que detecte el nuevo tipo de terreno. */
    public float RaycastDist = 0.3f;

    /* Número asociado al layer "Road" (obtenido mediante GetMask). */
    private int RoadLayerMask = 64;

    /* RaycastHit del vehículo respecto al terreno que pisa. */
    private RaycastHit RCHTerrain;

    /* Collider del RaycastHit que devuelve el tipo de terreno que pisa. */
    private Collider TerrainType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountRoadWheels();
        Debug.Log(RCHTerrain.collider);
    }

    int CountRoadWheels()
    {
        int RoadWheels = 0;

        for (int i = 0; i < Wheels.Length; i++)
        {
            Transform current = Wheels[i];
            RoadWheels += Physics.Raycast(current.position, Vector3.down, out RaycastHit hit, RaycastDist) ? 1 : 0;
            RCHTerrain = hit;
            TerrainType = hit.collider;
        }

        return RoadWheels;
    }
}
