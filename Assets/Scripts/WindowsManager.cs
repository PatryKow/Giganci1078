using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] GameObject hud;
    public void OpenWindow()
    {
        gameObject.SetActive(true); //pokazuje okno w kt�rym jest skrypt uruchamiaj�cy t� metod�
        hud.SetActive(false); // ukrywa celownik, �ycie gracza i inne elementy HUDa
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false); //ukrywa okno
        hud.SetActive(true); // pokazuje na powr�t celownik itd.
    }

}
