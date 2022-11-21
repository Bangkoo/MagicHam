using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;

    public KeyCode jump;
    public KeyCode attack;
    public string moveH;
    public string moveV;

    public bool pause = true;

    void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        moveH = "none";
        moveV = "none";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jump) && !pause) 
        {
            movement.Jump();
        }
        if (Input.GetKeyDown(attack) && !pause)
        {
            movement.Attack();
        }
    }

    void FixedUpdate()
    {
        if (!pause)
        {
            movement.Move(Input.GetAxisRaw(moveH), Input.GetAxisRaw(moveV));
        }
    }
}
