using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    public List<PlayerData> playersData = new List<PlayerData>();

    [SerializeField]
    public List<RoleData> roles = new List<RoleData>(RoleData.AllRoles);

    public UIDocument MainPage;
    public UIDocument AddPlayer;
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
        MainPage = GameObject.Find("MainPageDocument").GetComponent<UIDocument>();
        AddPlayer = GameObject.Find("AddPlayerDocument").GetComponent<UIDocument>();


        MainPage.GetComponent<MainPage>().newGame.clicked += () =>
        {
            router.path = RouterPaths.AddPlayer;

            AddPlayer addPlayer = AddPlayer.GetComponent<AddPlayer>();
            addPlayer.RenderPlayers();

       
        };

    }

    public void AddNewPlayer()
    {
        playersData.Add(new PlayerData());
    }


    public void CreateGame()
    {
        game = new Game();
    }
}
