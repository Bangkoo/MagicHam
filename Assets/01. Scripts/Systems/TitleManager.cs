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
    [SerializeField] private Canvas menu;
    public GameObject miniTitle;

    float time;
    float F_time = 1.0f;
    Color alpha;

    bool flash = true;
    bool canPressR = false;

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
        if(Input.GetKeyDown(KeyCode.R) && canPressR)
        {
            CancelInvoke();
            audioSource.Play();
            canPressR = false;
            miniTitle.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            menu.gameObject.SetActive(true);
        }
    }

    void MainScene()
    {
        StartCoroutine(MainFlow());
    }

    IEnumerator MainFlow() //로고 후 타이틀
    {
        logo.gameObject.SetActive(true);
        time = 0.0f;
        alpha = logo.color;

        yield return new WaitForSeconds(1.0f);

        while (alpha.a > 0.0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            logo.color = alpha;
            yield return null;
        }
        logo.gameObject.SetActive(false);

        yield return new WaitForSeconds(2.0f);

        gameManager.SendMessage("FadeOut");
        title.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        canPressR = true;
        Invoke("PressRFlash", 0.5f);
    }

    void PressRFlash()
    {
        flash = flash ? false : true;
        title.transform.GetChild(2).gameObject.SetActive(flash);
        Invoke("PressRFlash", 0.5f);
    }

    public void test()
    {
        Debug.Log("굳");
    }
}
