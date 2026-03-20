using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    //Movimento
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    //Animação
    [SerializeField] private Animator _animator;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Update()
    {

        if (!PauseMenu.isPaused)
        {
            //Animação

            //Movimento
            isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                rb.linearVelocity = Vector2.up * jumpForce;
                _animator.SetBool("isJumping", true);
            }

            if (isJumping && Input.GetButton("Jump"))
            {
                if (jumpTimer < jumpTime)
                {
                    rb.linearVelocity = Vector2.up * jumpForce;
                    jumpTimer += Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
                jumpTimer = 0;
                _animator.SetBool("isJumping", false);
            }
        }
    }

    public void Start()
    {
        _animator.SetBool("isJumping", false);
    }
}
