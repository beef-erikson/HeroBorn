/********************************
 * ItemBehavior.cs
 * Adds 1 to Items in GameBehavior.cs when collided with, prints LootReport() and Destroys itself.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 ********************************/

using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehavior>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player") return;
        
        Destroy(this.transform.gameObject);
        Debug.Log("item collected!");
        gameManager.Items += 1;
        gameManager.PrintLootReport();
    }
}
