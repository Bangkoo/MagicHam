using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;
    float horizontalMove;
    float verticalMove;
    bool isAction = false;

    void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !isAction) //점프
        {
            movement.Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) //공격
        {
            movement.Attack();
        }
    }

    void FixedUpdate()
    {
        movement.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //이동
    }
}
