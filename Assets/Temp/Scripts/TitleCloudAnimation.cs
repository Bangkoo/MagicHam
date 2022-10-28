using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCloudAnimation : MonoBehaviour
{
    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition += new Vector2(Time.deltaTime * 50.0f, 0);

        if(rect.anchoredPosition.x > 800.0f)
        {
            rect.anchoredPosition = new Vector2(-800.0f, 0);
        }
    }
}
