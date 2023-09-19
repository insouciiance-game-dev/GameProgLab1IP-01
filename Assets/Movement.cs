using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidBody;

    [SerializeField]
    private float _moveSpeed = 5f;

    [SerializeField]
    private float _jumpForce = 10f;

    private bool _isGrounded;

    // Start is called before the first frame update
    private void Start()
    {
        _isGrounded = true;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput * _moveSpeed, _rigidBody.velocity.y);
        _rigidBody.velocity = movement;

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }

    // OnCollisionEnter2D is called when a collision occurs.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _isGrounded = true;
    }
}
