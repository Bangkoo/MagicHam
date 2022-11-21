using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setter : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject cam;
    public GameManager gm;

    public Transform p1Pos;
    public Transform p2Pos;
    public Transform camPos;
    public Vector2 camCenter;
    public Vector2 camSize;

    // Start is called before the first frame update

    private void Awake()
    {
        cam = GameObject.Find("Main Camera");
        player1 = cam.GetComponent<CameraController>().player1;
        player2 = cam.GetComponent<CameraController>().player2;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        player1.transform.position = p1Pos.position;
        player2.transform.position = p2Pos.position;
        cam.transform.position = camPos.position;
        cam.GetComponent<CameraController>().center = camCenter;
        cam.GetComponent<CameraController>().size = camSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(camCenter, camSize);
    }
}
