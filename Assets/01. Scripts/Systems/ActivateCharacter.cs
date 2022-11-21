using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCharacter : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;
    public bool playerPause;

    // Start is called before the first frame update
    private void Awake()
    {
        player1 = GameObject.Find("Main Camera").GetComponent<CameraController>().player1.GetComponent<PlayerController>();
        player2 = GameObject.Find("Main Camera").GetComponent<CameraController>().player2.GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
    }
    private void OnDisable()
    {

    }
    void Start()
    {
        player1.pause = playerPause;
        player2.pause = playerPause;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
