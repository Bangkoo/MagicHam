using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Image logo;
    [SerializeField] private Canvas title;
    [SerializeField] private Canvas background;
    //
    [SerializeField] private Canvas menu;
    [SerializeField] private Canvas subMenu;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioClip[] bgmList;
    [SerializeField] private Canvas background2;
    float vol;

    float time;
    float F_time = 1.0f;
    Color alpha;

    bool flash = true;
    bool canPressR = false;
    bool canPressEsc = false;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        audioSource = this.GetComponent<AudioSource>();

        logo = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        title = this.transform.GetChild(1).GetComponent<Canvas>();
        background = this.transform.GetChild(2).GetComponent<Canvas>();
        menu = this.transform.GetChild(3).GetComponent<Canvas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MainScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && canPressR) //
        {
            audioSource.Play();
            CancelInvoke();
            canPressR = false;
            StartCoroutine(AfterPressR());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canPressEsc)
        {
            goMainMenu();
        }
    }

    void MainScene()
    {
        StartCoroutine(MainFlow());
    }

    IEnumerator MainFlow() { 
        time = 0.0f;
        alpha = logo.color;

        yield return new WaitForSeconds(1.0f);
        logo.gameObject.SetActive(true);
        while (alpha.a < 1.0f)
        {
            time += (Time.deltaTime / F_time);
            alpha.a = Mathf.Lerp(0, 1, time);
            logo.color = alpha;
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);
        time = 0.0f;

        while (alpha.a > 0.0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            logo.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);

        logo.gameObject.SetActive(false);
        gameManager.SendMessage("FadeOut");
        title.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        bgm.Play();
        Invoke("PressRFlash", 1.0f);
    }

    IEnumerator AfterPressR()
    {
        gameManager.SendMessage("FadeIn");
        vol = bgm.volume;
        time = 0.0f;

        while (vol > 0.0f)
        {
            time += Time.deltaTime / F_time;
            vol = Mathf.Lerp(1, 0, time);
            bgm.volume = vol;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        title.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
        background2.gameObject.SetActive(true);
        canPressEsc = true;
        gameManager.SendMessage("QuickFadeOut");
        bgm.clip = bgmList[1];
        bgm.volume = 1.0f;
        bgm.Play();
    }

    void PressRFlash()
    {
        flash = flash ? false : true;
        canPressR = true;
        title.transform.GetChild(2).gameObject.SetActive(flash);
        Invoke("PressRFlash", 0.5f);
    }

    ///button event
    public void goMainMenu()
    {
        subMenu.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
    public void goSubMenu()
    {
        menu.gameObject.SetActive(false);
        subMenu.gameObject.SetActive(true);
    }
    public void goSetting()
    {
        menu.gameObject.SetActive(false);
    }
    public void goCredit()
    {
        menu.gameObject.SetActive(false);
    }
    public void gameExit()
    {
        gameManager.SendMessage("FadeIn");
        StartCoroutine(End());
    }
    public void player1()
    {
        gameManager.GetComponent<GameData>().players = 1;
        gameManager.SendMessage("NextStage");
    }
    public void player2()
    {
        gameManager.GetComponent<GameData>().players = 2;
        gameManager.SendMessage("NextStage");
    }
    //
    IEnumerator End()
    {
        gameManager.SendMessage("FadeIn");
        vol = bgm.volume;
        time = 0.0f;

        while (vol > 0.0f)
        {
            time += Time.deltaTime / F_time;
            vol = Mathf.Lerp(1, 0, time);
            bgm.volume = vol;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);
        Application.Quit();
    }

}
