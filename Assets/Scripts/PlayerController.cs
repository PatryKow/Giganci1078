using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f; //szybkość naszej postaci
    public float gravity = -10; //przyspieszenie ziemskie 
    public float jumpHight = 100;
    bool hasJumped = false;
    Vector3 velocity; //wyliczona prędkość w każdym kierunku
    CharacterController characterController; //komponent Character Controller

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            hasJumped = true;
            velocity.y = jumpHight;
        }

        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Somethin Collided!!!");
        Debug.Log(hit.gameObject.name);
        hasJumped = false;
    }

}
