using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : WindowsManager // ten skrypt dziedziczy po WindowsManager - co oznacza, ¿e mo¿emy skorzystaæ z metod, które tam s¹,
                                        // bez potrzeby pobierania dostêpu do nich lub przepisywania kodu
{
    GameplayManager gameplayManager;
    private void Start()
    {
        gameObject.SetActive(false); //na pocz¹tku gry nie chcemy ¿eby menu pauzy by³o widoczne wiêc je wy³¹czamy
        gameplayManager = FindAnyObjectByType<GameplayManager>(); //szukamy na ca³ej scenie komponentu/skryptu GameplayManager
    }

    public void OnPause()
    {
        OpenWindow(); //jedna z metod zawartych w WindowsManager
        Cursor.lockState = CursorLockMode.None; //odblokowuje kursor
        Cursor.visible = true; // i sprawia ¿eby by³ widoczny
        Time.timeScale = 0; // zatrzymuje czas
        gameplayManager.isPaused = true; //i wysy³a informacje ¿e gra jest zatrzymana
    }

    public void OnResume()
    {
        CloseWindow();
        Cursor.lockState = CursorLockMode.Locked; //blokuje kursor
        Cursor.visible = false; // ukrywa go
        Time.timeScale = 1; //ustawia prêdkoœæ czasu na normaln¹
        gameplayManager.isPaused = false; // i wysy³a informacje ¿e gra jest wznowiona
    }

}
