using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;
    public bool playerPause = true;

    // Start is called before the first frame update
    private void Awake()
    {
        player1 = GameObject.Find("Main Camera").GetComponent<CameraController>().player1.GetComponent<PlayerController>();
        player2 = GameObject.Find("Main Camera").GetComponent<CameraController>().player2.GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        player1.pause = playerPause;
        player2.pause = playerPause;
        GameObject.Find("Main Camera").GetComponent<CameraController>().player1.GetComponent<CharacterAnimation>().EndMoving();
        GameObject.Find("Main Camera").GetComponent<CameraController>().player2.GetComponent<CharacterAnimation>().EndMoving();
    }
    private void OnDisable()
    {
        player1.pause = !playerPause;
        player2.pause = !playerPause;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}