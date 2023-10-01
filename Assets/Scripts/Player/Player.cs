using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player 
{
    readonly PlayerData playerData;
    Role role;
    private bool isAlive;
    private Role attacker;
    private Role protector;
    public Player (PlayerData playerData, Role role)
    {
        this.playerData = playerData;
        this.role = role;
    }

    public bool IsAlive { get => isAlive; set => isAlive = value; }
    public PlayerData PlayerData => playerData;
    public Role Role { get => role; set => role = value; }
    public Role Attacker { get => attacker; set => attacker = value; }
    public Role Protector { get => protector; set => protector = value; }

    public bool IsDead()
    {
        if (attacker != null)
        {
            if (protector == null)
            {
                isAlive = false;
            }

        }

        protector = null;
        attacker = null;

        return false;
    }
}
