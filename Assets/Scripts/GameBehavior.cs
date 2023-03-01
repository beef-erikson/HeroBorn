using System.Collections.Generic;
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
    public Stack<Loot> LootStack = new Stack<Loot>();
    
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    private string _state;
    
    public string State { get; set; }

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
    /// Initializes state and populates LootStack
    /// </summary>
    public void Initialize()
    {
        _state = "Game Manager initialized...";
        _state.FancyDebug();
        Debug.Log(_state);

        LootStack.Push(new Loot("Sword of Doom", 5));
        LootStack.Push(new Loot("HP Boost", 1));
        LootStack.Push(new Loot("Golden Key", 3));
        LootStack.Push(new Loot("Pair of Winged Boots", 2));
        LootStack.Push(new Loot("Mythril Bracer", 4));
    }

    /// <summary>
    /// Prints out number of items in LootStack
    /// </summary>
    public void PrintLootReport()
    {
        var currentItem = LootStack.Pop();
        var nextItem = LootStack.Peek();
        
        Debug.Log($"You got a {currentItem.Name}! You've got a good chance of finding " +
                  $"a {nextItem.Name} next!");
        Debug.Log($"There are {LootStack.Count} random loot items waiting for you!");
    }
}
