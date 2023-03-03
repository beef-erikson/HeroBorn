/********************************
 * Weapon.cs
 * Serializable Weapon struct and WeaponShop class.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 * Public Methods:
 * public void PrintWeaponStats() - Prints the name and damage of the weapon.
 * 
 ********************************/

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
