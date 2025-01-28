using UnityEngine;

public class PlayerInfo : MonoBehaviour //skrypt zarz¹dzaj¹cy zdrowiem gracza
{
    [SerializeField] int playerHealth = 100; //aktualna iloœæ punktów ¿ycia
    [SerializeField] float hpBar = 1; //pasek ¿ycia mo¿e byæ wyœwietlany ca³y (1) wcale (0) lub w czêsci (np. 0.5)
    [SerializeField] int maxHp = 100; //maksymalny poziom zdrowia

    HUDController hud; //odniesienie do skryptu zarz¹dzaj¹cego wyœwietlaniem zdrowia na ekranie
    private void Start()
    {
        hud = GetComponent<HUDController>(); //pobranie dostêpu do skryptu (musi siê znajdowaæ w obiekcie Player
        //hud.HpUpdate(PlayerHealth.ToString()); - wykomentowane linijki by³y omawiane na zajêciach, pozwalaj¹ na wyœwietlenie zdrowia w formie liczby
        hud.HpUpdate((float)playerHealth/maxHp); // pozwala na wyœwietlenie zdrowia w formie paska
    }

    public int PlayerHealth //zabezpieczenie zmiennej playerHealth przed zmian¹ przez inne skrypty ni¿ ten
    {
        get { return playerHealth; } //wywo³anie na zewn¹trz zmiennej PlayerHealth, zwraca wartoœæ playerHealth
        set //zmiana zmiennej PlayerHealth
        { 
            playerHealth = value; // przypisuje now¹ wartoœæ
        hud.HpUpdate((float)playerHealth / maxHp); // i uruchamia metodê HpUpdate (znajduj¹c¹ siê w skrypcie HUDController)
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
