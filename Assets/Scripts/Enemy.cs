using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour 
{
    [SerializeField] int hp;
    [SerializeField] int damage;

    public void OnShot(int damage) //metoda uruchamiana gdy gracz strzeli w przeciwnika
                                   //(damage - parametr podawany do metody, w zale�no�ci od broni, mog� by� zadane r�ne obra�enia)
    {
        hp -= damage; //odejmowanie obra�e� od zdrowia
        print(hp); //wy�wietlanie w konsoli aktualnej ilo�ci zdrowia (g��wnie w celach sprawdzenia czy dzia�a)
        CheckIfDead();
    }

    void CheckIfDead() // metoda sprawdzaj�ca czy przeciwnik ma jeszcze punkty zdrowia
    {
        if (hp <= 0) //je�eli nie
        {
            Destroy(this.gameObject); //to usuwa obiekt (przeciwnika)
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //sprawdza czy obiekt, kt�ry znalaz� si� w zasi�gu jest oznaczony jako gracz
        {
            PlayerInfo target = other.gameObject.GetComponent<PlayerInfo>(); //pobiera dost�p do skryptu zarz�dzaj�cego �yciem
            HitPlayer(target, damage);
        }

    }

    void HitPlayer(PlayerInfo player, int damage)
    {
        player.PlayerHealth -= damage; //zadaje graczowi obra�enia w ilo�ci "damage"
    }
}
