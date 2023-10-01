using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Role 
{
    protected string description;
    private Roles roleEnum;

    public Roles RoleEnum { get => roleEnum;}

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
        new (){ role = Roles.Vampire, count = 1 },
        new (){ role = Roles.Doctor, count = 1 },
        new (){ role = Roles.Observer, count = 1 }
    };

    public Roles role;
    public int count;
}

