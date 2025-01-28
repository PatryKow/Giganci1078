using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour //skrypt zarz�dzaj�cy zatrzymywaniem gry
{
    GameplayManager gameplayManager;
    public bool isPaused = false;
    [SerializeField] PauseMenu pauseMenu; //element interfejsu, kt�ry b�dzie si� pojawia� po zatrzymaniu gry

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // na pocz�tku gry blokujemy pozycj� kursora na �rodku ekranu
        Cursor.visible = false; // i ukrywamy go
        if (gameplayManager == null) // skrypty tego typu - dzia�aj�ce przez ca�� gr�, s� typu Singleton - musi wyst�powa� jeden i tylko jeden. Tu sprawdzamy czy ten skrypt ju� istnieje w danej scenie
        {
            gameplayManager = this; // je�li nie to tworzymy go
        }
        else
        {
            Destroy(gameObject); // je�eli tak, to usuwamy niepotrzebny
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //sprawdzamy czy w poprzedniej klatce zosta� wci�ni�ty klawisz ESC
        {
            PauseManager();
        }
    }

    public void PauseManager()
    {
        if (!isPaused) // je�eli zmienna isPaused jest obecnie false - gra nie jest zatrzymana
        {
            pauseMenu.OnPause(); //uruchamia skrypt z menu pauzy OnPause
            isPaused = true; // przestawia "flag�" na tak - gra jest zapauzowana
        }
        else
        {
            pauseMenu.OnResume();
            isPaused = false;
        }
    }
}
