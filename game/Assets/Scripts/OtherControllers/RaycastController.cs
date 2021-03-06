using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It allows to detect the terrain that the vehicle is treading on.
/// 
/// @author Alejandro Goicoechea Rom?n
/// </summary>
public class RaycastController : MonoBehaviour
{
    /* Lista con las ruedas del veh?culo. */
    public Transform[] Wheels = new Transform[4];

    /* Distancia de Raycast para que detecte el nuevo tipo de terreno. */
    public float RaycastDist = 0.3f;

    /* RaycastHit del veh?culo respecto al terreno que pisa. */
    private RaycastHit RCHTerrain;

    /* Collider del RaycastHit que devuelve el tipo de terreno que pisa el veh?culo. */
    private Collider TerrainCollider;

    /* N?mero asociado al layer del terreno que pisa el veh?culo. */
    private int TerrainType;

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastTerrain();
    }

    void RaycastTerrain()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 3f)) {
            RCHTerrain = hit;
            TerrainCollider = RCHTerrain.collider;
            TerrainType = TerrainCollider.transform.gameObject.layer;

            if (LayerMask.LayerToName(TerrainType) == "Ground" || LayerMask.LayerToName(TerrainType) == "Road")
            {
                Debug.DrawRay(transform.position, Vector3.down * 10f, Color.green, Time.fixedDeltaTime);
                Debug.Log(LayerMask.LayerToName(TerrainType));
            }
        }
        else
            Debug.DrawRay(transform.position, Vector3.down * 10f, Color.red, Time.fixedDeltaTime);
    }
}
