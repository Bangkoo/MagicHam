using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public RectTransform rect;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rect.transform.position += rect.transform.right * Time.deltaTime * speed;
        if(rect.localPosition.x >= 950.0f)
        {
            rect.localPosition = new Vector3(-957.0f, 552.0f, 0.0f);
        }
    }
}
