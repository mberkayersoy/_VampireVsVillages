using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : State
{
    public Start(Game sm) : base(sm)
    {
    }
    public override void OnEnter()
    {
        game.playerList = MatchRolesWithPlayers(GameManager.Instance.players, RoleData.AllRoles);
    }

    public List<Player> MatchRolesWithPlayers(List<PlayerData> playerDataList, List<RoleData> allRoleDatas)
    {
        System.Random random = new System.Random();

        List<Roles> allRoles = GetGameRoles(allRoleDatas);

        if (allRoles.Count != playerDataList.Count)
        {
            throw new ArgumentException("Lists count doesn't match.");
        }

        List<Player> matchedPlayers = new List<Player>();
        List<Roles> remainingRoles = new List<Roles>(allRoles);

        foreach (PlayerData playerData in playerDataList)
        {
            int randomIndex = random.Next(remainingRoles.Count);
            Roles randomRole = remainingRoles[randomIndex];
            remainingRoles.RemoveAt(randomIndex);

            Player player = new Player(playerData, new Role(randomRole));
            
            matchedPlayers.Add(player);
        }

         
        return matchedPlayers;
    }

    public List<Roles> GetGameRoles(List<RoleData> allRoleDatas)
    {
        List<Roles> allRoles = new List<Roles>();
        // total villagers count;
        RoleData villagers = new RoleData(Roles.Villager, GameManager.Instance.players.Count - GetRolesAmount());
        RoleData.AllRoles.Add(villagers);

        foreach (RoleData roleData in allRoleDatas)
        {
            for (int i = 0; i < roleData.count; i++)
            {
                allRoles.Add(roleData.role);
            }
        }

        return allRoles;
    }

    public int GetRolesAmount()
    {
        int totalRole = 0;
        foreach (RoleData roleData in RoleData.AllRoles)
        {
            totalRole += roleData.count;
        }
        return totalRole;
    }

    public override void OnExit()
    {
        // To do: if options night or day.
        //game.SetState(game.nightState);
        game.SetState(game.dayState);
    }
}
