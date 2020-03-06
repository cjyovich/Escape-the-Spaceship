using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A script to handle player movement.
 * Mouse pans camera left and right.
 * WASD moves camera around the room.
 * Utilizes Character Controller for collisions.
 */
public class CameraController : MonoBehaviour
{
    public float speedH;
    public float speedV;

    private float yaw = 0.0f;

    private int speed = 5;

    private CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //pans camera left and right with mouse
        yaw += speedH * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0f, yaw, 0f);

        //moves camera around the room using character controller
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward * v * speed * Time.deltaTime;
        Vector3 right = transform.right * h * speed * Time.deltaTime;

        cc.Move(forward + right);

    }
}
