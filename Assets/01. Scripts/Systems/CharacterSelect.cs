using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Image cursor;
    public Image line;
    public Animator anim;
    private new AudioSource audio;
    public Image otherCursor;
    public Sprite twoPCursor;
    public GameObject character;
    public SelectManager sel;

    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointEnter()
    {
        cursor.gameObject.SetActive(true);
        line.gameObject.SetActive(true);
        anim.SetBool("isPointerEnter", true);
        audio.Play();
    }
    public void OnPointExit()
    {
        cursor.gameObject.SetActive(false);
        line.gameObject.SetActive(false);
        anim.SetBool("isPointerEnter", false);
    }
    public void OnPointClick()
    {
        if (sel.count == 0) //1p
        {
            otherCursor.sprite = twoPCursor;
            character.AddComponent<Player1KeySetting>();
            character.SetActive(true);
            sel.count++;
            sel.GetComponent<AudioSource>().Play();
            this.gameObject.SetActive(false);
        }
        else //2p
        {
            character.AddComponent<Player2KeySetting>();
            character.SetActive(true);
            sel.count++;
            sel.GetComponent<AudioSource>().Play();
            this.gameObject.SetActive(false);
        }
    }
}
