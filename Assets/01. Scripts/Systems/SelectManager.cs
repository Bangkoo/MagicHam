using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameData gameData;
    public int players;
    public int count = 0;
    bool flag = true;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameData = GameObject.Find("GameManager").GetComponent<GameData>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager.QuickFadeOut();
        players = gameData.players;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == players && flag)
        {
            flag = false;
            gameManager.NextStage();
        }
    }
}
