using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour 
{
    [SerializeField] int hp;
    [SerializeField] int damage;

    public void OnShot(int damage)
    {
        hp -= damage;
        print(hp);
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInfo target = other.gameObject.GetComponent<PlayerInfo>();
            HitPlayer(target, damage);
        }

    }

    void HitPlayer(PlayerInfo player, int damage)
    {
        player.PlayerHealth -= damage;
    }
}
