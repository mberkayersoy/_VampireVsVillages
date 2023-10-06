using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player 
{
    readonly PlayerData playerData;
    Role role;
    private bool isDead;
    private Role attacker;
    private Role protector;

    public Player (PlayerData playerData, Role role)
    {
        this.playerData = playerData;
        this.role = role;
        role.MyPlayer = this;
    }

    public bool IsDead { get => isDead; set => isDead = value; }
    public PlayerData PlayerData => playerData;
    public Role Role { get => role; set => role = value; }
    public Role Attacker { get => attacker; set => attacker = value; }
    public Role Protector { get => protector; set => protector = value; }

    public bool CheckIsDead()
    {
        if (attacker != null)
        {
            if (protector != null)
            {
                Debug.Log(protector.RoleType + " successfully protect " + playerData.Name + " from vampire.");
            }
            else
            {
                // to do: Give info => Vampire killed playerData.Name
                isDead = true;
                Debug.Log(attacker.RoleType + " killed " + playerData.Name);
            }
        }


        protector = null;
        attacker = null;

        return isDead;
    }
}
