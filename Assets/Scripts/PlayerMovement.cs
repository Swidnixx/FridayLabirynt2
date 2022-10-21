using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;

    CharacterController controller;

    [SerializeField] Transform groundSensor;
    [SerializeField] LayerMask groundLayer;

    bool grounded;
    private float velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Movement();
        GroundSensor();
        Gravity();
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("Skok");
            velocity = -10;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Pickup"))
        {
            hit.gameObject.GetComponent<Pickup>().Pick();
        }
    }

    void GroundSensor()
    {
        RaycastHit hit;
        grounded = Physics.Raycast(groundSensor.position, Vector3.down, out hit, 0.4f, groundLayer);

        if(grounded)
        {

            switch(hit.collider.tag)
            {
                case "FastFloor":
                    speed = 16;
                    break;

                case "SlowFloor":
                    speed = 4;
                    break;

                default:
                    speed = 10;
                    break;
            }
        }
    }
    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * inputY + transform.right * inputX;
        controller.Move( movement * speed * Time.deltaTime );
    }
    void Gravity()
    {
        if(grounded && velocity > 0)
        {
            velocity = 0f;
            return;
        }

        if(velocity < 55)
        {
            velocity += 9.81f * Time.deltaTime;
        }

        controller.Move( Vector3.down * velocity * Time.deltaTime );
    }
}
