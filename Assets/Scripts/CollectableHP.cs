using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHP : MonoBehaviour
{
    // skrypt do zbierania obiektów dodaj¹cych zdrowie
    [SerializeField] int healAmount = 50; //serialize field pozwala na przypisanie wartoœci w Unity w panelu "Inspector"
    [SerializeField] int maxHpAmount = 150;

    private void OnTriggerEnter(Collider other) //metoda OnTriggerEnter jest wbudowan¹ metod¹ Unity (klasa MonoBehaviour)
                                                //aktywuje kod po wejœciu w trigger - obiekt posiadaj¹cy komponent Collider pozwala na w³¹czenie tej opcji
    {
        int playerHealth = other.GetComponent<PlayerInfo>().PlayerHealth; //pobiera zmienn¹ PlayerHealth ze skryptu PlayerInfo
        if (playerHealth+healAmount >= maxHpAmount) // sprawdza czy zwróci graczowi ca³e zdrowie lub przekroczy jego maksymaln¹ iloœæ
        {
            playerHealth = maxHpAmount;             // ustawia aktualne ¿ycie na maksymalny poziom
            Destroy(this.gameObject);               // usuwa obiekt
        }
        else if (playerHealth+healAmount < maxHpAmount) //je¿eli aktualne ¿ycie plus to co zbierzemy nie uleczy do koñca
        {
            playerHealth += healAmount;                 //dodaje do aktualnego zdrowia to ile leczy obiekt
            Destroy(this.gameObject);
        }
        if (playerHealth == maxHpAmount)            //je¿eli gracz ju¿ ma maksymalne zdrowie, nie bêdzie móg³ zebraæ obiektu
        {
            print("You've reached max HP!"); // wyœwietli w konsoli komunikat
        }
        other.GetComponent<PlayerInfo>().PlayerHealth = playerHealth; //wysy³a aktualne zdrowie do skryptu który tym zarz¹dza
    }
}
