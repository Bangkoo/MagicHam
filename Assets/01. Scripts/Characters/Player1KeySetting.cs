using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1KeySetting : MonoBehaviour
{
    [SerializeField] PlayerController key;
    // Start is called before the first frame update
    void Awake()
    {
        key = this.GetComponent<PlayerController>();
        key.jump = KeyCode.Space;
        key.attack = KeyCode.RightShift;
        key.moveH = "1pHorizontal";
        key.moveV = "1pVertical";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
