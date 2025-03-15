using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    private float speed = 12f;
    private float gravity = -9.18f * 2;
    private float jumpHeight = 3f;

    [SerializeField] private Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    
    private bool isGrounded;
    private bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f - gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        }

        else
        {
            isMoving = false;
        }

        lastPosition = transform.position;
    }
}
