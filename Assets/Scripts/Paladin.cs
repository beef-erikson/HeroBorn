/********************************
 * Paladin.cs
 * Inherits from Character. Creates a named paladin with a weapon from Weapon.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 * Public Methods:
 * public override void PrintStatsInfo() - Prints out message with Paladin's name and weapon.
 * public int GetStackCount<TU>() where TU : T - Gets stack count from inventory.
 * 
 ********************************/

using UnityEngine;

public class Paladin : Character
{
    private readonly Weapon _weapon;

    /// <summary>
    /// Constructor for Paladin.
    /// </summary>
    /// <param name="name">Name of Paladin.</param>
    /// <param name="weapon">Weapon that is being used.</param>
    public Paladin(string name, Weapon weapon): base(name)
    {
        this._weapon = weapon;
    }

    /// <summary>
    /// Prints out message with Paladin's name and weapon.
    /// </summary>
    public override void PrintStatsInfo()
    {
        Debug.Log($"Hail {this.name} - take up your {this._weapon.name}!");
    }
}
