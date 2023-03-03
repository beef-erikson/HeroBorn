/********************************
 * Shop.cs
 * Shop class that handles Collectable items.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 * Public Methods:
 * public void AddItem(T newItem) - Adds new item of type Collectable to _inventory.
 * public int GetStackCount<TU>() where TU : T - Gets stack count from inventory.
 * 
 ********************************/

using System.Collections.Generic;
using System.Linq;

public class Shop<T> where T : Collectable
{
    private readonly List<T> _inventory = new List<T>();

    /// <summary>
    /// Adds new item of type Collectable to _inventory.
    /// </summary>
    /// <param name="newItem">Collectable to add.</param>
    public void AddItem(T newItem)
    {
        _inventory.Add(newItem);
    }

    /// <summary>
    /// Gets stack count from inventory.
    /// </summary>
    /// <typeparam name="TU">Type from Collectable.</typeparam>
    /// <returns>Number of items from selected Collectable item.</returns>
    public int GetStackCount<TU>() where TU : T
    {
        return _inventory.OfType<TU>().Count();
    }
}
