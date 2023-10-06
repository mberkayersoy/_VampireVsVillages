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
        Debug.Log("Observer Selected: " + player.PlayerData.Name + "\n" +
             player.PlayerData.Name + " is a " + player.Role.RoleType);
    }
    public override List<Player> GetAccessiblePlayers(List<Player> playerList)
    {
        List<Player> accessiblePlayer = new List<Player>();
        foreach (Player player in playerList)
        {
            if (player != this.myPlayer && !player.IsDead)
            {
                accessiblePlayer.Add(player);
            }
        }

        return accessiblePlayer;
    }
    public Roles Observe(Player player)
    {
        return player.Role.RoleType;
    }

}
