using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHP : MonoBehaviour
{
    // skrypt do zbierania obiekt�w dodaj�cych zdrowie
    [SerializeField] int healAmount = 50; //serialize field pozwala na przypisanie warto�ci w Unity w panelu "Inspector"
    [SerializeField] int maxHpAmount = 150;

    private void OnTriggerEnter(Collider other) //metoda OnTriggerEnter jest wbudowan� metod� Unity (klasa MonoBehaviour)
                                                //aktywuje kod po wej�ciu w trigger - obiekt posiadaj�cy komponent Collider pozwala na w��czenie tej opcji
    {
        int playerHealth = other.GetComponent<PlayerInfo>().PlayerHealth; //pobiera zmienn� PlayerHealth ze skryptu PlayerInfo
        if (playerHealth+healAmount >= maxHpAmount) // sprawdza czy zwr�ci graczowi ca�e zdrowie lub przekroczy jego maksymaln� ilo��
        {
            playerHealth = maxHpAmount;             // ustawia aktualne �ycie na maksymalny poziom
            Destroy(this.gameObject);               // usuwa obiekt
        }
        else if (playerHealth+healAmount < maxHpAmount) //je�eli aktualne �ycie plus to co zbierzemy nie uleczy do ko�ca
        {
            playerHealth += healAmount;                 //dodaje do aktualnego zdrowia to ile leczy obiekt
            Destroy(this.gameObject);
        }
        if (playerHealth == maxHpAmount)            //je�eli gracz ju� ma maksymalne zdrowie, nie b�dzie m�g� zebra� obiektu
        {
            print("You've reached max HP!"); // wy�wietli w konsoli komunikat
        }
        other.GetComponent<PlayerInfo>().PlayerHealth = playerHealth; //wysy�a aktualne zdrowie do skryptu kt�ry tym zarz�dza
    }
}
