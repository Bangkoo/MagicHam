using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;

    public KeyCode jump;
    public KeyCode attack;
    public string moveH;
    public string moveV;

    bool pause = false;

    void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        moveH = "none";
        moveV = "none";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jump) && !pause) //점프
        {
            movement.Jump();
        }
        if (Input.GetKeyDown(attack)) //공격
        {
            movement.Attack();
        }
    }

    void FixedUpdate()
    {
        movement.Move(Input.GetAxisRaw(moveH), Input.GetAxisRaw(moveV)); //이동
    }
}
