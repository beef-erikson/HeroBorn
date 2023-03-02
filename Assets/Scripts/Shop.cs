using System.Collections.Generic;

public class Shop<T>
{
    public readonly List<T> inventory = new List<T>();

    public void AddItem(T newItem)
    {
        inventory.Add(newItem);
    }
}
