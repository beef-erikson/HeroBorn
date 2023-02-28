using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    
    private const int MaxItems = 1;
    
    public TMP_Text healthText;
    public TMP_Text itemText;
    public TMP_Text progressText;
    public Button winButton;
    public Button lossButton;
    
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    
    /// <summary>
    /// Getter/setter for _itemsCollected
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
    /// Getter/setter for _playerHP
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
    /// Restarts the first scene and resumes normal time scale
    /// </summary>
    public void RestartScene()
    {
        Utilities.RestartLevel();
    }

    /// <summary>
    /// Updates progressText with provided string
    /// </summary>
    /// <param name="updatedText">String to update</param>
    public void UpdateScene(string updatedText)
    {
        progressText.text = updatedText;
        Time.timeScale = 0f;
    }
    
    /// <summary>
    /// Sets initial UI texts
    /// </summary>
    private void Start()
    {
        itemText.text += _itemsCollected;
        healthText.text += _playerHP;
    }
}
