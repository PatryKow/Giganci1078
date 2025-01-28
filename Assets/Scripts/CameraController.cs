using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensivity = 100f; //czułość myszy
    public Transform playerBody; //referencja do naszego gracza, obrót kamery będzie obracał naszym graczem
    float xRotation = 0f; //obrót względem osi x kamery

    //Start jest wywoływany raz na początku gry
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //zmienia stan kursora na zablokowany po środku ekranu
        playerBody = transform.parent; //pobiera dostęp do obiektu w którym znajduje się kamera (w "Hierarchy" w Unity, kamera jest "wewnątrz" obiektu "Player")
    }

    //Update jest wywoływany co klatkę
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime; //ruch myszy w osi X pomnożony razy zmienną mouseSensitivity i czas pomiędzy klatkami (Time.deltaTime)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime; // jak wyżej tylko w osi Y

        xRotation -= mouseY; // obrót kamery wokół X powoduje spojrzenie góra/dół więc jest uzależniony od mouseY
        xRotation = Mathf.Clamp(xRotation, -90f, 50f); //ustala zakres obrotu, zabezpiecza przed "zrobieniem salta"

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //przypisanie gotowego xRotation do obrotu kamery
        playerBody.Rotate(Vector3.up * mouseX); //obraca gracza wokół osi Y - Mnoży zmienną mouseX razy 0,1,0 (Vector3.up)
                                                //(wszystkie osie można zobaczyć w okienku pogdlądu sceny w Unity)
    }
}
