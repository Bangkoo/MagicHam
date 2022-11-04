using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2KeySetting : MonoBehaviour
{
    [SerializeField] PlayerController key;
    // Start is called before the first frame update
    void Awake()
    {
        key = this.GetComponent<PlayerController>();
        key.jump = KeyCode.LeftShift;
        key.attack = KeyCode.LeftControl;
        key.moveH = "2pHorizontal";
        key.moveV = "2pVertical";
    }

    // Update is called once per frame
    void Update()
    {

    }
}