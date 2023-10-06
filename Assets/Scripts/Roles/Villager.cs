using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Role
{
    public Villager() : base(Roles.Villager)
    {

    }
    public override void Ability(Player player)
    {
        // Should never work
        Debug.LogError("Villager Ability");
    }
    public override List<Player> GetAccessiblePlayers(List<Player> playerList)
    {
        return base.GetAccessiblePlayers(playerList);
    }
}
