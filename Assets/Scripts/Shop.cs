using System.Collections.Generic;
using System.Linq;

public class Shop<T> where T : Collectable
{
    public readonly List<T> inventory = new List<T>();

    public void AddItem(T newItem)
    {
        inventory.Add(newItem);
    }

    public int GetStackCount<TU>() where TU : T
    {
        return inventory.OfType<TU>().Count();
    }
}
