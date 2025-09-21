using UnityEngine;

public class BalutController : MonoBehaviour
{
    public float tapImpulse = 5f;      // How strong the bounce is
    public float moveSpeed = 5f;         // Left-right movement speed
    public float maxYSpeed = 12f;        // Limit vertical speed so it doesn't fly away

    private Rigidbody2D rb;
    private bool is_on_floor = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundRayLenght = 8f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D groundChecker = Physics2D.Raycast(transform.position, Vector2.down, groundRayLenght, groundLayer);
        if (groundChecker.collider != null)
        {
            is_on_floor = true;
        }
        else
        {
            is_on_floor = false;
        }

        // Bounce up when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && is_on_floor)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // reset vertical velocity
            rb.AddForce(Vector2.up * tapImpulse, ForceMode2D.Impulse);
        }

        // Horizontal movement
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            moveInput = 1f;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Clamp max Y speed
        if (rb.velocity.y > maxYSpeed)
            rb.velocity = new Vector2(rb.velocity.x, maxYSpeed);
    }
}