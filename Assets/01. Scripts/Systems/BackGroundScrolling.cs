using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    public Transform start;
    public Transform end;
    private float startX;
    private float endX;

    // Start is called before the first frame update
    void Start()
    {
        startX = start.position.x;
        endX = end.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(Time.deltaTime, 0, 0);

        if (gameObject.transform.position.x > endX)
            gameObject.transform.position = new Vector3(startX, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
