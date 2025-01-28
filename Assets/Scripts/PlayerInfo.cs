using UnityEngine;

public class PlayerInfo : MonoBehaviour //skrypt zarz�dzaj�cy zdrowiem gracza
{
    [SerializeField] int playerHealth = 100; //aktualna ilo�� punkt�w �ycia
    [SerializeField] float hpBar = 1; //pasek �ycia mo�e by� wy�wietlany ca�y (1) wcale (0) lub w cz�sci (np. 0.5)
    [SerializeField] int maxHp = 100; //maksymalny poziom zdrowia

    HUDController hud; //odniesienie do skryptu zarz�dzaj�cego wy�wietlaniem zdrowia na ekranie
    private void Start()
    {
        hud = GetComponent<HUDController>(); //pobranie dost�pu do skryptu (musi si� znajdowa� w obiekcie Player
        //hud.HpUpdate(PlayerHealth.ToString()); - wykomentowane linijki by�y omawiane na zaj�ciach, pozwalaj� na wy�wietlenie zdrowia w formie liczby
        hud.HpUpdate((float)playerHealth/maxHp); // pozwala na wy�wietlenie zdrowia w formie paska
    }

    public int PlayerHealth //zabezpieczenie zmiennej playerHealth przed zmian� przez inne skrypty ni� ten
    {
        get { return playerHealth; } //wywo�anie na zewn�trz zmiennej PlayerHealth, zwraca warto�� playerHealth
        set //zmiana zmiennej PlayerHealth
        { 
            playerHealth = value; // przypisuje now� warto��
        hud.HpUpdate((float)playerHealth / maxHp); // i uruchamia metod� HpUpdate (znajduj�c� si� w skrypcie HUDController)
            //hud.HpUpdate(playerHealth.ToString());
        }
    }

    public void GetDamage(int damage) 
    {
        PlayerHealth -= damage;
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (PlayerHealth <= 0) 
        {
            Time.timeScale = 0; //zatrzymuje czas w grze
            print("You Died!");
        }
    }
}
