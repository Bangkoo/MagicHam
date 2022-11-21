using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNext : MonoBehaviour
{
    GameManager gm;
    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

        gm.NextStage();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
