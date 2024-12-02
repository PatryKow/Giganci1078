using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO", order = 0)]

public class WeaponSO : ScriptableObject
{
    public int ammoAmount = 0;
    public AmmoType ammoType;
    [Tooltip("Bullets per sec")] public float fireRate = 2f;
    public int damage = 10;

    public enum AmmoType
    {
        Pistol,
        Shotgun,
        AssaultRifle,
        MarksmanRifle
    }

    public void Shoot()
    {
        ammoAmount -= 1;
    }
}
