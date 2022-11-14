using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Image cursor;
    public Image line;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointEnter()
    {
        Debug.Log("진입");
        cursor.gameObject.SetActive(true);
        line.gameObject.SetActive(true);
    }
    public void OnPointExit()
    {
        Debug.Log("나감");
        cursor.gameObject.SetActive(false);
        line.gameObject.SetActive(false);
    }
}
