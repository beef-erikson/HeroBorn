/********************************
 * Collectable.cs
 * Holds collectible items types.
 * Used to properly display counts for items using Shop<Collectable>.GetStockCount<T>().
 * Holds Potions and Antidotes.
 * Last Edit: 3-3-23
 * Troy Martin
 * 
 ********************************/

public class Collectable
{
    protected string name;
}

public class Potion : Collectable
{
    public Potion()
    {
        this.name = "Potion";
    }
}

public class Antidote : Collectable
{
    public Antidote()
    {
        this.name = "Antidote";
    }
}