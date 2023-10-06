using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Role
{
    public Vampire() : base(Roles.Vampire)
    {

    }
    public override void Ability(Player player)
    {
        TryKill(player);
    }

    private void TryKill(Player player)
    {
        player.Attacker = this;
        Debug.Log("Vampire Attacked + " + player.PlayerData.Name);
    }

    public override List<Player> GetAccessiblePlayers(List<Player> playerList)
    {
        List<Player> accessiblePlayer = new List<Player>();
        foreach (Player player in playerList)
        {
            if (player.Role.RoleType != roleType && !player.IsDead)
            {
                accessiblePlayer.Add(player);
            }
        }

        return accessiblePlayer;
    }

}
