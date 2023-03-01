using System.Collections;
using System.Collections.Generic;
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
