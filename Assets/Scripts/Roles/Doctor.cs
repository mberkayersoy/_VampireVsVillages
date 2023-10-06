using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Role
{
    Player lastProtectedPlayer;
    public Doctor() : base(Roles.Doctor)
    {

    }
    public override void Ability(Player player)
    {
        Protect(player);
        Debug.Log("Doctor Selected: " + player.PlayerData.Name);

    }
    public override List<Player> GetAccessiblePlayers(List<Player> playerList)
    {
        List<Player> accessiblePlayer = new List<Player>();
        foreach (Player player in playerList)
        {
            if (player != lastProtectedPlayer && !player.IsDead)
            {
                accessiblePlayer.Add(player);
            }
        }

        return accessiblePlayer;
    }

    public void Protect(Player player)
    {
        player.Protector = this;
        lastProtectedPlayer = player;

    }
}
