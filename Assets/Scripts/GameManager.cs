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

    public GameObject UIManager;
    public UIDocument MainPage;
    public UIDocument AddPlayer;
    public Router router;
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
        UIManager = GameObject.Find("UIManager");
        MainPage = GameObject.Find("MainPageDocument").GetComponent<UIDocument>();
        AddPlayer = GameObject.Find("AddPlayerDocument").GetComponent<UIDocument>();

        router = UIManager.GetComponent<Router>();
        router.path = RouterPaths.Main;

        MainPage.GetComponent<MainPage>().newGame.clicked += () =>
        {
            router.path = RouterPaths.AddPlayer;

            AddPlayer addPlayer = AddPlayer.GetComponent<AddPlayer>();
            addPlayer.RenderPlayers();

            addPlayer.OnPlayerAdded += (object sender, EventArgs a) =>
            {
                playersData.Add(new PlayerData());
                addPlayer.RenderPlayers();
            };
            addPlayer.OnPlayerUpdated += (object sender, EventArgs a) =>
            {
                addPlayer.RenderPlayers();
            };
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
