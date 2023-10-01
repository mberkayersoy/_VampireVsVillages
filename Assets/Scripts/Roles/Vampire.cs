using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Role
{
    public override void Ability(Player player)
    {
        TryKill(player);
    }

    private void TryKill(Player player)
    {
        player.Attacker = this;
    }


}
