using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<PlayerData> players = new List<PlayerData>();

    public GameObject UIManager;
    public UIDocument MainPage;
    public UIDocument AddPlayer;

    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.Find("UIManager");
        MainPage = GameObject.Find("MainPageDocument").GetComponent<UIDocument>();
        AddPlayer = GameObject.Find("AddPlayerDocument").GetComponent<UIDocument>();

        UIManager.GetComponent<Router>().path = RouterPaths.Main;

        MainPage.GetComponent<MainPage>().newGame.clicked += () =>
        {
            UIManager.GetComponent<Router>().path = RouterPaths.AddPlayer;

            AddPlayer addPlayer = AddPlayer.GetComponent<AddPlayer>();
            addPlayer.RenderPlayers(players);

            addPlayer.OnPlayerAdded += (object sender, EventArgs a) =>
            {
                players.Add(new PlayerData());
                addPlayer.RenderPlayers(players);
            };
            addPlayer.OnPlayerUpdated += (object sender, EventArgs a) =>
            {
                addPlayer.RenderPlayers(players);
            };
        };
    }
}
