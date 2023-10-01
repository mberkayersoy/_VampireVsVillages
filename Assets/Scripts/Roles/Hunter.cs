using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : Role
{
    public override void Ability(Player player)
    {
        Observe(player);
    }

    public RoleEnum Observe(Player player)
    {
        return player.Role.RoleEnum;
    }

}
