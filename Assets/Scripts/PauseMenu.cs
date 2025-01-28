using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : WindowsManager // ten skrypt dziedziczy po WindowsManager - co oznacza, �e mo�emy skorzysta� z metod, kt�re tam s�,
                                        // bez potrzeby pobierania dost�pu do nich lub przepisywania kodu
{
    GameplayManager gameplayManager;
    private void Start()
    {
        gameObject.SetActive(false); //na pocz�tku gry nie chcemy �eby menu pauzy by�o widoczne wi�c je wy��czamy
        gameplayManager = FindAnyObjectByType<GameplayManager>(); //szukamy na ca�ej scenie komponentu/skryptu GameplayManager
    }

    public void OnPause()
    {
        OpenWindow(); //jedna z metod zawartych w WindowsManager
        Cursor.lockState = CursorLockMode.None; //odblokowuje kursor
        Cursor.visible = true; // i sprawia �eby by� widoczny
        Time.timeScale = 0; // zatrzymuje czas
        gameplayManager.isPaused = true; //i wysy�a informacje �e gra jest zatrzymana
    }

    public void OnResume()
    {
        CloseWindow();
        Cursor.lockState = CursorLockMode.Locked; //blokuje kursor
        Cursor.visible = false; // ukrywa go
        Time.timeScale = 1; //ustawia pr�dko�� czasu na normaln�
        gameplayManager.isPaused = false; // i wysy�a informacje �e gra jest wznowiona
    }

}
