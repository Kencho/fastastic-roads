using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public float YawAngle = 0.0f;

    public Transform TargetTransform = null;
    public Transform CameraTransform = null;

    public Vector3 CameraOffset = new Vector3 (0.0f, 5.0f, -10.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetTransform != null)
        {
            transform.position = TargetTransform.position;
        }

        Quaternion rotation = Quaternion.Euler(0.0f, YawAngle, 0.0f);

        if (CameraTransform != null)
        {
            CameraTransform.position = transform.position + CameraOffset;
            CameraTransform.LookAt (TargetTransform);
        }
    }
}
