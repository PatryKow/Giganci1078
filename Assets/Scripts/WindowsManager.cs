using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] GameObject hud;
    public void OpenWindow()
    {
        gameObject.SetActive(true); //pokazuje okno w którym jest skrypt uruchamiaj¹cy t¹ metodê
        hud.SetActive(false); // ukrywa celownik, ¿ycie gracza i inne elementy HUDa
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false); //ukrywa okno
        hud.SetActive(true); // pokazuje na powrót celownik itd.
    }

}
