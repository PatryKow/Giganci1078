using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour //skrypt zarz¹dzaj¹cy zatrzymywaniem gry
{
    GameplayManager gameplayManager;
    public bool isPaused = false;
    [SerializeField] PauseMenu pauseMenu; //element interfejsu, który bêdzie siê pojawia³ po zatrzymaniu gry

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // na pocz¹tku gry blokujemy pozycjê kursora na œrodku ekranu
        Cursor.visible = false; // i ukrywamy go
        if (gameplayManager == null) // skrypty tego typu - dzia³aj¹ce przez ca³¹ grê, s¹ typu Singleton - musi wystêpowaæ jeden i tylko jeden. Tu sprawdzamy czy ten skrypt ju¿ istnieje w danej scenie
        {
            gameplayManager = this; // jeœli nie to tworzymy go
        }
        else
        {
            Destroy(gameObject); // je¿eli tak, to usuwamy niepotrzebny
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //sprawdzamy czy w poprzedniej klatce zosta³ wciœniêty klawisz ESC
        {
            PauseManager();
        }
    }

    public void PauseManager()
    {
        if (!isPaused) // je¿eli zmienna isPaused jest obecnie false - gra nie jest zatrzymana
        {
            pauseMenu.OnPause(); //uruchamia skrypt z menu pauzy OnPause
            isPaused = true; // przestawia "flagê" na tak - gra jest zapauzowana
        }
        else
        {
            pauseMenu.OnResume();
            isPaused = false;
        }
    }
}
