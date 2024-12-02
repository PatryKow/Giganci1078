using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHP : MonoBehaviour
{
    [SerializeField] int healAmount = 50;
    [SerializeField] int maxHpAmount = 150;

    private void OnTriggerEnter(Collider other)
    {
        int playerHealth = other.GetComponent<PlayerInfo>().PlayerHealth;
        if (playerHealth+healAmount >= maxHpAmount) // if will heal to max amount
        {
            playerHealth = maxHpAmount;             // set hp to max HP
            Destroy(this.gameObject);
        }
        else if (playerHealth+healAmount < maxHpAmount) // if will heal less then to a max amount
        {
            playerHealth += healAmount;                 // add Healing amount to players health
            Destroy(this.gameObject);
        }
        if (playerHealth == maxHpAmount)            // if player already healed to max, print message without destroying collectable
        {
            print("You've reached max HP!");
        }
        other.GetComponent<PlayerInfo>().PlayerHealth = playerHealth;
    }
}
