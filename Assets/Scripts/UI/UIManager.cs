using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Router router;
    public StartPage startPage;
    public NightPage nightPage;
    public VotePage votePage;
    public DayPage dayPage;


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

    // Start is called before the first frame update
    void Start()
    {
        router = GetComponent<Router>();
        Debug.Log(router == null ? "Null router." : "Router found.");
        startPage = GetComponentInChildren<StartPage>();
        nightPage = GetComponentInChildren<NightPage>();
        votePage = GetComponentInChildren<VotePage>();
        dayPage = GetComponentInChildren<DayPage>();
    }
}
