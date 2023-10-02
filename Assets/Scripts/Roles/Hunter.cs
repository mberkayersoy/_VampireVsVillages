using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : Role
{
    public Hunter() : base(Roles.Observer)
    {

    }
    public override void Ability(Player player)
    {
        Observe(player);
    }

    public Roles Observe(Player player)
    {
        return player.Role.RoleType;
    }

}
