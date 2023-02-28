using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;

    // Constructors
    /// <summary>
    /// Empty constructor
    /// </summary>
    public Character()
    {
        Reset();
    }

    /// <summary>
    /// Character with name
    /// </summary>
    /// <param name="name">Name of the character</param>
    public Character(string name)
    {
        this.name = name;
    }

    // Methods
    /// <summary>
    /// Prints the name and experience of the Character
    /// </summary>
    public virtual void PrintStatsInfo()
    {
        Debug.Log($"Hero: {this.name} - {this.exp} EXP");
    }

    /// <summary>
    /// Resets player to default values
    /// </summary>
    private void Reset()
    {
        this.name = "Not assigned";
        this.exp = 0;
    }
}