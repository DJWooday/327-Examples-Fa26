using UnityEngine;
using UnityEngine.InputSystem;

public class BeanSchMovement : MonoBehaviour
{
    public float speed = 3;
    public float jumpForce = 10;
    public Vector2 movement;
    bool jump;
    public bool isGrounded;
    public Transform foot;

    public LayerMask groundingLayers;

    Rigidbody rb;
    InputAction moveAction, jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }


    // Update is called once per frame
    void Update()
    {
        //float horMove = 0;
        //if (Keyboard.current.aKey.isPressed) { horMove = -1; }
        //if (Keyboard.current.dKey.isPressed) { horMove = 1; }
        movement = moveAction.ReadValue<Vector2>();

        //Vector3 moveVec = new Vector3(horMove, 0, 0) * Time.deltaTime * speed;
        //rb.MovePosition(moveVec + transform.position);

        jump = (isGrounded && jumpAction.WasPressedThisFrame() || jump);
    }

    private void FixedUpdate()
    {
        // Move
        Vector3 forComponent = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized * movement.y;
        Vector3 horComponent = Camera.main.transform.right * movement.x;
        Vector3 moveVec = (forComponent + horComponent).normalized * speed * Time.deltaTime;
        rb.MovePosition(moveVec + transform.position);

        // Determining grounding
        //if (Physics.Raycast(foot.position, Vector3.down, .05f)) 
        //    isGrounded = true;
        //else isGrounded = false;
        isGrounded = Physics.CheckSphere(foot.position, .2f, groundingLayers);

        // Jump
        if (jump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }

        rb.AddForce(Vector3.down * 18f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(foot.position, .2f);
    }
}
