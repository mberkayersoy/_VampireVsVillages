using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Role
{
    protected string description;
    protected Roles roleType;


    public Roles RoleType { get => RoleType;}

    public Role(Roles roleType)
    {
        this.roleType = roleType;
    }
    public virtual void Ability(Player player) { }
}


public enum Roles
{
    Villager,
    Vampire,
    Doctor,
    Observer,
}

[Serializable]
public class RoleData
{
    public static List<RoleData> AllRoles = new List<RoleData>() {
        new (Roles.Vampire, 1),//{ role = Roles.Vampire, count = 1 },
        new (Roles.Doctor, 1),//{ role = Roles.Doctor, count = 1 },
        new (Roles.Observer, 1)//{ role = Roles.Observer, count = 1 }
    };

    public Roles role;
    public int count;
    public RoleData(Roles role, int count)
    {
        this.role = role;
        this.count = count;
    }

}

