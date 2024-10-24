using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour 
{
    [SerializeField] int hp;

    public void OnShot(int damage)
    {
        hp -= damage;
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (hp <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
