using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private Animator animator;

    [Header("Variaveis")]
    [SerializeField] private float jumpForce = 16f;
    [SerializeField] private float speed = 8f;

    [Header("Gravidade")]
    [SerializeField] private float normalGravity = 3f;
    [SerializeField] private float fastFallGravity = 8f;

    [Header("Referencias")]
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D rb;

    [Header("Booleans")]
    [SerializeField] private bool isOnFloor;

    [Header("Checks")]
    [SerializeField] private Transform floorCheck;
    [SerializeField] private LayerMask floorLayer;

    private float moveInput;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb.gravityScale = normalGravity;
    }

    void Update()
    {
        // INPUT DE MOVIMENTO
        moveInput = Input.GetAxisRaw("Horizontal");

        // ANIMA��O DE CORRER
        animator.SetBool("taCorrendo", moveInput != 0);

        // VIRAR PERSONAGEM
        if (moveInput > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (moveInput < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        // PULO
        if (Input.GetKeyDown(KeyCode.W) && isOnFloor)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnFloor = false;
            animator.SetBool("taPulando", true);
        }

        // QUEDA R�PIDA (FAST FALL)
        if (Input.GetKey(KeyCode.S) && !isOnFloor)
        {
            rb.gravityScale = fastFallGravity;
        }
        else
        {
            rb.gravityScale = normalGravity;
        }
    }

    void FixedUpdate()
    {
        // MOVIMENTO COM F�SICA
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
            rb.gravityScale = normalGravity;
            animator.SetBool("taPulando", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = false;
        }
    }
}
