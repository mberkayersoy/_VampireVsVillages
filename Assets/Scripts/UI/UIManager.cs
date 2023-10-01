using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameManager gameManager;
    Router router;

  

    // Start is called before the first frame update
    void Start()
    {
        router = GetComponent<Router>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
