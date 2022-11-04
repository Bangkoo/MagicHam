using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image Panel;
    float F_time = 1.0f;
    float time;
    Color alpha;

    void Awake()
    {
        Panel = this.transform.GetChild(0).GetChild(0).GetComponent<Image>(); //fade에 사용할 검은 화면
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        StartCoroutine(FadeFlowIn());
    }
    public void FadeOut()
    {
        StartCoroutine(FadeFlowOut());
    }

    IEnumerator FadeFlowIn()
    {
        Panel.gameObject.SetActive(true);
        time = 0.0f;
        alpha = Panel.color;
        while (alpha.a < 1.0f)
        {
            time += (Time.deltaTime / F_time);
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }
    IEnumerator FadeFlowOut()
    {
        time = 0.0f;
        alpha = Panel.color;
        while (alpha.a > 0.0f)
        {
            time += (Time.deltaTime / F_time);
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
}
