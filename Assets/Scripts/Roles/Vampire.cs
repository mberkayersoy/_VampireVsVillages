using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Role
{
    public Vampire() : base(Roles.Vampire)
    {

    }
    public override void Ability(Player player)
    {
        TryKill(player);
    }

    private void TryKill(Player player)
    {
        Debug.Log("Selected player: " + player.PlayerData.Name);
        player.Attacker = this;
    }


}
