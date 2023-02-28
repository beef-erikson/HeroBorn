using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Character
{
    public Weapon weapon;

    public Paladin(string name, Weapon weapon): base(name)
    {
        this.weapon = weapon;
    }

    public override void PrintStatsInfo()
    {
        Debug.Log($"Hail {this.name} - take up your {this.weapon.name}!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
