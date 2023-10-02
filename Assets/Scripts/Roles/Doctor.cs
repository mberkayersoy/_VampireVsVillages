using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Role
{
    public Doctor() : base(Roles.Doctor)
    {

    }
    public override void Ability(Player player)
    {
        Protect(player);
    }

    public void Protect(Player player)
    {
        player.Protector = this;
    }
}
