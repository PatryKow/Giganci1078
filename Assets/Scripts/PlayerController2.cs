using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float baseSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravity;
    [SerializeField] float sprintMultiplier = 2;
    float speed = 0;
    Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = baseSpeed;
    }

    void Update()
    {
        PlayerMove();
        Jump();
        Sprint();
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        velocity.y -= gravity;

        Vector3 move = transform.right * x + velocity + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (characterController.isGrounded) { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpHeight;
            }
        }
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = baseSpeed * sprintMultiplier;
        }
        else
        {
            speed = baseSpeed;
        }
    }
}
