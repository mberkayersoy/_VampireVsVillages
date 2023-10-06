using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Role
{
    protected string description;
    protected Roles roleType;
    [SerializeReference]
    protected Player myPlayer;

    public Roles RoleType { get => roleType;}
    public Player MyPlayer { get => myPlayer; set => myPlayer = value; }

    public Role(Roles roleType)
    {
        this.roleType = roleType;
    }
    public virtual void Ability(Player player) { }
    public virtual List<Player> GetAccessiblePlayers(List<Player> playerList) 
    {
        List<Player> accessiblePlayer = new List<Player>();
        foreach (Player player in playerList)
        {
            if (!player.IsDead)
            {
                accessiblePlayer.Add(player);
            }
        }

        return playerList; 
    }

    public static Role CreateRoleClass(Roles roleType)
    {
        switch (roleType)
        {
            default:
            case Roles.Villager:
                return new Villager();
            case Roles.Vampire:
                return new Vampire();
            case Roles.Doctor:
                return new Doctor();
            case Roles.Observer:
                return new Hunter();
        }
    }
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

