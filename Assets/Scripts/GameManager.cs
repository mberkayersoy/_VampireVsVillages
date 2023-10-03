using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    public List<PlayerData> playersDataList = new List<PlayerData>();

    [SerializeField]
    public List<RoleData> roles = new List<RoleData>(RoleData.AllRoles);

    public Router router => UIManager.Instance.router;
    public Game game;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        // ...
    }

    public void NewGame()
    {
        router.path = RouterPaths.AddPlayer;

        AddPlayerPage addPlayer = UIManager.Instance.addPlayerPage;
        addPlayer.RenderPlayers();
    }

    public void AddNewPlayer()
    {
        playersDataList.Add(new PlayerData());
    }


    public void CreateGame()
    {
        game = new Game();
    }
}
