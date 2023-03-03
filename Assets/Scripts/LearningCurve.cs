/********************************
 * LearningCurve.cs
 * Various examples of basic C# and Unity concepts.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 * Public Methods:
 * public void ComputerAge() - Computes a modified age integer.
 * public int GenerateCharacter(string name, int level) - Prints out a character message.
 * public void Thievery() - Prints out wealth.
 * public void OpenTreasureChamber() - Prints out treasure chamber messages.
 * public void PrintCharacterAction() - Prints battle information based on characters action.
 * public void RollDice() - Prints the result based on diceRoll.
 * public void FindPartyMember() - Prints out party members.
 * public void HealthStatus() - Prints out health status until dead.
 * 
 ********************************/

using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    private const int CurrentAge = 30;
    public int addedAge = 1;

    public float pi = 3.14f;
    public string firstName = "Beef";
    public bool isAuthor = true;

    public int currentGold = 32;

    public bool pureOfHeart = true;
    public bool hasSecretIncantation = false;
    public string rareItem = "Relic Stone";

    public string characterAction = "Attack";

    public int diceRoll = 7;

    public int playerLives = 3;

    public Transform camTF;
    public GameObject directionLightGO;
    public Transform lightTF;

    // Start is called before the first frame update
    private void Start()
    {
        Character hero = new();
        var villain = hero;
        villain.name = "Sir Beef Erikson";
        hero.PrintStatsInfo();
        villain.PrintStatsInfo();

        Character heroine = new("Sally");
        heroine.PrintStatsInfo();

        Weapon huntingBow = new("Hunting Bow", 105);
        Weapon warBow = huntingBow;
        warBow.name = "War Bow";
        warBow.damage = 155;
        huntingBow.PrintWeaponStats();
        warBow.PrintWeaponStats();

        Paladin knight = new("Sir Arthur", huntingBow);
        knight.PrintStatsInfo();

        camTF = this.GetComponent<Transform>();
        Debug.Log(camTF.localPosition);
        //directionLightGO = GameObject.Find("Directional Light");
        lightTF = directionLightGO.GetComponent<Transform>();
        Debug.Log(lightTF.localPosition);
    }

    
    /// <summary>
    /// Computes a modified age integer
    /// </summary>
    public void ComputeAge()
    {
        Debug.Log(CurrentAge + addedAge);
    }

    /// <summary>
    /// Prints out a character message
    /// </summary>
    public int GenerateCharacter(string name, int level)
    {
        Debug.Log($"Character: {name} - Level: {level}");
        return level += 5;
    }

    /// <summary>
    /// Prints out wealth
    /// </summary>
    public void Thievery()
    {
        if (currentGold > 50)
        {
            Debug.Log("You're rolling in it!");
        }
        else if (currentGold < 15)
        {
            Debug.Log("Not much there to steal...");
        }
        else
        {
            Debug.Log("Looks like your purse is in the sweet spot.");
        }
    }

    /// <summary>
    /// Treasure chamber messages
    /// </summary>
    public void OpenTreasureChamber()
    {
        if (pureOfHeart && rareItem == "Relic Stone")
        {
            if (!hasSecretIncantation)
            {
                Debug.Log("You have the spirit, but not the knowledge.");
            }
            else
            {
                Debug.Log("Hey, congrats!");
            }
        }
        else
        {
            Debug.Log("Something is amiss...");
        }
    }

    /// <summary>
    /// Prints battle information based on character action
    /// </summary>
    public void PrintCharacterAction()
    {
        switch(characterAction)
        {
            case "Heal":
                Debug.Log("Potion sent.");
                break;
            case "Attack":
                Debug.Log("To arms!");
                break;
            default:
                Debug.Log("Shields up.");
                break;
        }
    }

    /// <summary>
    /// Prints the result based on the value of diceRoll
    /// </summary>
    public void RollDice()
    {
        switch(diceRoll)
        {
            case 7:
            case 15:
                Debug.Log("Mediocre damage, not bad.");
                break;
            case 20:
                Debug.Log("Critical hit, the creature goes down!");
                break;
            default:
                Debug.Log("You completely missed and fell on your face.");
                break;
        }
    }

    /// <summary>
    /// Prints out party members
    /// </summary>
    public void FindPartyMember()
    {
        List<string> questPartyMembers = new()
    
        {
            "Grim the Barbarian",
            "Merlin the Wise",
            "Sterling the Knight"
        };

        for (var i = 0; i < questPartyMembers.Count; i++)
        {
            Debug.Log($"Name: {questPartyMembers[i]}");

            if (questPartyMembers[i] == "Merlin the Wise")
            {
                Debug.Log("Welcome back Merlin!");
            }
        }

        foreach (var partyMember in questPartyMembers)
        {
            Debug.Log($"{partyMember} - Here!");
        }
    }

    /// <summary>
    /// Prints out health until dead
    /// </summary>
    public void HealthStatus()
    {
        while (playerLives > 0)
        {
            Debug.Log("Still alive!");
            playerLives--;
        }

        Debug.Log("Player KO'd...");
    }
}
