using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Weapon
{
    public string name;
    public int damage;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name of the weapon</param>
    /// <param name="damage">Damage for the weapon</param>
    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    /// <summary>
    /// Prints the name and damage of weapon
    /// </summary>
    public void PrintWeaponStats()
    {
        Debug.Log($"Weapon: {this.name} - {this.damage} DMG");
    }
}

[Serializable]
public class WeaponShop
{
    public List<Weapon> inventory;
}
