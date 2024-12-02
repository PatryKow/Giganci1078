using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    //public int stamina = 100;
    HUDController hud;
    private void Start()
    {
        hud = GetComponent<HUDController>();
        hud.HpUpdate(PlayerHealth.ToString());
    }

    public int PlayerHealth
    {
        get { return playerHealth; }
        set 
        { 
            playerHealth = value;
            hud.HpUpdate(playerHealth.ToString());
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
            Time.timeScale = 0;
            print("You Died!");
        }
    }
}
