using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Role 
{
    protected string description;
    private RoleEnum roleEnum;

    public RoleEnum RoleEnum { get => roleEnum;}

    public virtual void Ability(Player player) { }
}

public enum RoleEnum
{
    Villager,
    Vampire,
    Hunter
}
