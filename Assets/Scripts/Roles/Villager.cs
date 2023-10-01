using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Role
{
    public override void Ability(Player player)
    {
        // Should never work
        Debug.LogError("Villager Ability");
    }
}
