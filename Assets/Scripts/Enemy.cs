using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour 
{
    [SerializeField] int hp;
    [SerializeField] int damage;

    public void OnShot(int damage) //metoda uruchamiana gdy gracz strzeli w przeciwnika
                                   //(damage - parametr podawany do metody, w zale¿noœci od broni, mog¹ byæ zadane ró¿ne obra¿enia)
    {
        hp -= damage; //odejmowanie obra¿eñ od zdrowia
        print(hp); //wyœwietlanie w konsoli aktualnej iloœci zdrowia (g³ównie w celach sprawdzenia czy dzia³a)
        CheckIfDead();
    }

    void CheckIfDead() // metoda sprawdzaj¹ca czy przeciwnik ma jeszcze punkty zdrowia
    {
        if (hp <= 0) //je¿eli nie
        {
            Destroy(this.gameObject); //to usuwa obiekt (przeciwnika)
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //sprawdza czy obiekt, który znalaz³ siê w zasiêgu jest oznaczony jako gracz
        {
            PlayerInfo target = other.gameObject.GetComponent<PlayerInfo>(); //pobiera dostêp do skryptu zarz¹dzaj¹cego ¿yciem
            HitPlayer(target, damage);
        }

    }

    void HitPlayer(PlayerInfo player, int damage)
    {
        player.PlayerHealth -= damage; //zadaje graczowi obra¿enia w iloœci "damage"
    }
}
