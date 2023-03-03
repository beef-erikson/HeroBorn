/********************************
 * Loot.cs
 * Loot struct containing Name and Rarity.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 ********************************/

public struct Loot
{
    public string Name { get; set; }
    public int Rarity { get; set; }

    /// <summary>
    /// Creates a new loot member.
    /// </summary>
    /// <param name="name">Name of the item.</param>
    /// <param name="rarity">Number for rarity of the item.</param>
    public Loot(string name, int rarity)
    {
        this.Name = name;
        this.Rarity = rarity;
    }
}
