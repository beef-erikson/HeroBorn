using System.Collections.Generic;
using System.Linq;
using CustomExtensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour, IManager
{
    private const int MaxItems = 1;
    
    public TMP_Text healthText;
    public TMP_Text itemText;
    public TMP_Text progressText;
    public Button winButton;
    public Button lossButton;
    public string State { get; set; }

    private delegate void DebugDelegate(string newText);

    private readonly DebugDelegate _debug = Print;
    
    private readonly Stack<Loot> _lootStack = new Stack<Loot>();
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    private string _state;
    


    /// <summary>
    /// Getter/setter for _itemsCollected.
    /// </summary>
    public int Items
    {
        get => _itemsCollected; 
        set 
        {
            _itemsCollected = value;
            itemText.text = "Items Collected: " + Items;

            // Win game
            if (_itemsCollected >= MaxItems)
            {
                winButton.gameObject.SetActive(true);
                UpdateScene("You've found all the items!");
            }
            // Update items
            else
            {
                progressText.text = $"Item found, only {MaxItems - _itemsCollected} more to go!";
            }

            Debug.Log($"Items: {_itemsCollected}");    
        }
    }

    /// <summary>
    /// Getter/setter for _playerHP.
    /// </summary>
    public int HP
    {
        get => _playerHP; 
        set
        {
            _playerHP = value;
            healthText.text = $"Player Health: {HP}";

            if (_playerHP <= 0)
            {
                lossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
            }
            else
            {
                progressText.text = "Ouch... that's gotta hurt.";
            }
        }
    }

    /// <summary>
    /// Restarts the first indexed scene and resumes normal time scale.
    /// </summary>
    public void RestartScene()
    {
        Utilities.RestartLevel(0);
    }

    /// <summary>
    /// Updates progressText with provided string.
    /// </summary>
    /// <param name="updatedText">String to update.</param>
    private void UpdateScene(string updatedText)
    {
        progressText.text = updatedText;
        Time.timeScale = 0f;
    }
    
    /// <summary>
    /// Sets initial UI texts.
    /// </summary>
    private void Start()
    {
        itemText.text += _itemsCollected;
        healthText.text += _playerHP;

        Initialize();
    }

    /// <summary>
    /// Initializes state and populates _lootStack
    /// </summary>
    public void Initialize()
    {
        _state = "Game Manager initialized...";
        _state.FancyDebug();
        _debug(_state);

        _lootStack.Push(new Loot("Sword of Doom", 5));
        _lootStack.Push(new Loot("HP Boost", 1));
        _lootStack.Push(new Loot("Golden Key", 3));
        _lootStack.Push(new Loot("Pair of Winged Boots", 2));
        _lootStack.Push(new Loot("Mythril Bracer", 4));

        FilterLoot();

        var itemShop = new Shop<Collectable>();
        itemShop.AddItem(new Potion());
        itemShop.AddItem(new Antidote());
        Debug.Log($"Items for sale: {itemShop.GetStackCount<Potion>()}");

        
    }

    /// <summary>
    /// Prints out number of items in _lootStack
    /// </summary>
    public void PrintLootReport()
    {
        var currentItem = _lootStack.Pop();
        var nextItem = _lootStack.Peek();
        
        Debug.Log($"You got a {currentItem.Name}! You've got a good chance of finding " +
                  $"a {nextItem.Name} next!");
        Debug.Log($"There are {_lootStack.Count} random loot items waiting for you!");
    }

    private void FilterLoot()
    {
        /*
        // Regular LINQ query
        var rareLoot = _lootStack
            .Where(item => item.Rarity >= 3)
            .OrderBy(item => item.Rarity)
            .Select(item => new { item.Name });
        */
        
        // Example of LINQ query comprehension syntax, mixing lambda with it.
        // Skips the first entry.
        var rareLoot = (from item in _lootStack
            where item.Rarity >= 3
            orderby item.Rarity
            select new {item.Name})
            .Skip(1);
        
        foreach (var item in rareLoot)
        {
            Debug.Log($"Rare item: {item.Name}!");
        }
    }

    private static void Print(string newText)
    {
        Debug.Log(newText);
    }
}
