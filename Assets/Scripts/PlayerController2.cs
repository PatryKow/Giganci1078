using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    CharacterController characterController; // deklaracja komponentu odpowiedzialnego za sterowanie postaci� gracza
    [SerializeField] float baseSpeed; //bazowa szybko��
    [SerializeField] float jumpHeight; //Wysoko�� skoku
    [SerializeField] float gravity; //warto�� przyci�gania ziemskiego
    [SerializeField] float sprintMultiplier = 2; //mno�nik pr�dko�ci gracza przy sprintowaniu
    float speed = 0; //zmienna do przechowywania pr�dko�ci
    Vector3 velocity; //"si�a" z jak� gracz si� przemieszcza (dotyczy wszystkich osi)

    void Start()
    {
        characterController = GetComponent<CharacterController>(); //znalezienie komponentu Character Controller
        speed = baseSpeed; // ustalenie pr�dko�ci na pocz�tkow� - z tak� gracz b�dzie si� przemieszcza� normalnie
    }

    void Update()
    {
        PlayerMove();
        Jump(); 
        Sprint(); 
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal"); //pobieranie danych wej�ciowych z kontrolera (lewo - prawo)
        float z = Input.GetAxis("Vertical"); //prz�d - ty�
        velocity.y -= gravity; // obni�anie "pr�dko�ci" gracza w osi y (g�ra - d�)

        Vector3 move = transform.right * x * speed + velocity + transform.forward * z * speed; //ustalanie kierunku w kt�rym gracz si� przemieszcza
        characterController.Move(move  * Time.deltaTime); // przemieszczenie gracza w ustalonym kierunku
    }

    void Jump()
    {
        if (characterController.isGrounded) {  //sprawdzenie czy gracz jest na ziemi (zapobiega skokom w powietrzu)
            if (Input.GetKeyDown(KeyCode.Space)) // sprawdzenie czy zosta�a wci�ni�ta spacja
            {
                velocity.y = jumpHeight; // dodanie do aktualnej "pr�dko�ci pionowej" gracza warto�ci r�wnej mocy skoku
            }
        }
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // sprawdzenie czy lewy shift JEST wci�ni�ty
        {
            speed = baseSpeed * sprintMultiplier; //mno�enie bazowej pr�dko�ci razy mno�nik
        }
        else // je�li nie jest wci�ni�ty
        {
            speed = baseSpeed; //ustalenie pr�dko�ci na pr�dko�� bazow�
        }
    }

}
