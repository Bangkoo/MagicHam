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
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !isAction) //����
        {
            movement.Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) //����
        {
            movement.Attack();
        }
    }

    void FixedUpdate()
    {
        movement.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //�̵�
    }
}
