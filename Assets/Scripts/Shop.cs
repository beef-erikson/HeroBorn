using System.Collections.Generic;
using System.Linq;

public class Shop<T> where T : Collectable
{
    private readonly List<T> _inventory = new List<T>();

    public void AddItem(T newItem)
    {
        _inventory.Add(newItem);
    }

    public int GetStackCount<TU>() where TU : T
    {
        return _inventory.OfType<TU>().Count();
    }
}
