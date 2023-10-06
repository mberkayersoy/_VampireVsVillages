using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Router router;
    public MainPage mainPage;
    public AddPlayerPage addPlayerPage;
    public StartPage startPage;
    public NightPage nightPage;
    public VotePage votePage;
    public DayPage dayPage;
    public InformationPage informationPage;

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
        router = GetComponent<Router>();

        mainPage = GetComponentInChildren<MainPage>();
        addPlayerPage = GetComponentInChildren<AddPlayerPage>();

        startPage = GetComponentInChildren<StartPage>();
        nightPage = GetComponentInChildren<NightPage>();
        votePage = GetComponentInChildren<VotePage>();
        dayPage = GetComponentInChildren<DayPage>();
        informationPage = GetComponentInChildren<InformationPage>();
    }
}
