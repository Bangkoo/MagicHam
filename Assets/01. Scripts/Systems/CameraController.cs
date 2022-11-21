using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1 = null;
    public GameObject player2 = null;
    [SerializeField] private GameManager gm;
    public float x1;
    public float x2;
    private float centerX;

    public Vector2 center;
    public Vector2 size;
    float height;
    float width;
   

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 != null && player2 != null)
        {
            x1 = player1.GetComponent<Transform>().position.x;
            x2 = player2.GetComponent<Transform>().position.x;
            centerX = (x1 + x2) / 2.0f;
        }
    }

    void LateUpdate()
    {
        transform.position = new Vector3(centerX, transform.position.y, -10.0f);

        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        transform.position = new Vector3(clampX, transform.position.y, -10.0f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }
}
