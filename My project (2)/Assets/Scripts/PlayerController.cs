
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool onGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(x, 0f, z).normalized;

        Vector3 velocity = rb.linearVelocity;
        velocity.x = movement.x * speed;
        velocity.z = movement.z * speed;
        rb.linearVelocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("A tecla ESPAÇO foi pressionada. No chão: " + onGround);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            Debug.Log("SALTO!");
        }
    }

   void OnCollisionEnter(Collision collision)
{
    CheckGround(collision, true);
}

void OnCollisionStay(Collision collision)
{
    CheckGround(collision, true);
}

void OnCollisionExit(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        onGround = false;
    }
}

void CheckGround(Collision collision, bool grounded)
{
    if (!collision.gameObject.CompareTag("Ground"))
        return;

    foreach (ContactPoint contact in collision.contacts)
    {
        // Só considera chão uma superfície por baixo do jogador.
        if (contact.normal.y > 0.5f)
        {
            onGround = grounded;
            return;
        }
    }
}
}