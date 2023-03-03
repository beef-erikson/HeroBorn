/********************************
 * Character.cs
 * Holds name and experience for Character.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 * Public Methods:
 * public virtual void PrintStatsInfo() - Prints the name and experience of Character.
 * 
 * Private Methods:
 * private void Reset() - Resets Character to default values.
 * 
 ********************************/

using UnityEngine;

public class Character
{
    public string name;
    private int _exp = 0;

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
        Debug.Log($"Hero: {this.name} - {this._exp} EXP");
    }

    /// <summary>
    /// Resets player to default values
    /// </summary>
    private void Reset()
    {
        this.name = "Not assigned";
        this._exp = 0;
    }
}