using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public int HitPoints = 10;
    public float Angle = 0.0f;
    public float RunSpeed = 100.0f;
    public float WalkBackSpeed = 50.0f;
    public float TurnSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController charController = GetComponent<CharacterController>();
        float speed = 0.0f;

        if (Input.GetAxis("Vertical") > 0.0f)
        {
            speed = Input.GetAxis("Vertical") * RunSpeed;
        } 
        else
        {
            if (Input.GetAxis("Vertical") < 0.0f)
            {
                speed = Input.GetAxis("Vertical") * WalkBackSpeed;
            }
        }

        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * TurnSpeed * Time.deltaTime);
        charController.SimpleMove(transform.forward * speed * Time.deltaTime);
    }
}
