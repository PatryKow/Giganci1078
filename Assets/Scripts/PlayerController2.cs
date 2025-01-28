using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    CharacterController characterController; // deklaracja komponentu odpowiedzialnego za sterowanie postaci¹ gracza
    [SerializeField] float baseSpeed; //bazowa szybkoœæ
    [SerializeField] float jumpHeight; //Wysokoœæ skoku
    [SerializeField] float gravity; //wartoœæ przyci¹gania ziemskiego
    [SerializeField] float sprintMultiplier = 2; //mno¿nik prêdkoœci gracza przy sprintowaniu
    float speed = 0; //zmienna do przechowywania prêdkoœci
    Vector3 velocity; //"si³a" z jak¹ gracz siê przemieszcza (dotyczy wszystkich osi)

    void Start()
    {
        characterController = GetComponent<CharacterController>(); //znalezienie komponentu Character Controller
        speed = baseSpeed; // ustalenie prêdkoœci na pocz¹tkow¹ - z tak¹ gracz bêdzie siê przemieszcza³ normalnie
    }

    void Update()
    {
        PlayerMove();
        Jump(); 
        Sprint(); 
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal"); //pobieranie danych wejœciowych z kontrolera (lewo - prawo)
        float z = Input.GetAxis("Vertical"); //przód - ty³
        velocity.y -= gravity; // obni¿anie "prêdkoœci" gracza w osi y (góra - dó³)

        Vector3 move = transform.right * x * speed + velocity + transform.forward * z * speed; //ustalanie kierunku w którym gracz siê przemieszcza
        characterController.Move(move  * Time.deltaTime); // przemieszczenie gracza w ustalonym kierunku
    }

    void Jump()
    {
        if (characterController.isGrounded) {  //sprawdzenie czy gracz jest na ziemi (zapobiega skokom w powietrzu)
            if (Input.GetKeyDown(KeyCode.Space)) // sprawdzenie czy zosta³a wciœniêta spacja
            {
                velocity.y = jumpHeight; // dodanie do aktualnej "prêdkoœci pionowej" gracza wartoœci równej mocy skoku
            }
        }
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // sprawdzenie czy lewy shift JEST wciœniêty
        {
            speed = baseSpeed * sprintMultiplier; //mno¿enie bazowej prêdkoœci razy mno¿nik
        }
        else // jeœli nie jest wciœniêty
        {
            speed = baseSpeed; //ustalenie prêdkoœci na prêdkoœæ bazow¹
        }
    }

}
