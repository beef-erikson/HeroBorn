/********************************
 * IManager.cs
 * Interface class for State and Initialize().
 * Last Edit: 3-3-23
 * Troy Martin
 * 
 ********************************/

public interface IManager 
{
    string State { get; set; }

    void Initialize();
}
