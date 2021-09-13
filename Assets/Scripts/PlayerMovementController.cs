using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 10;
    float horizontalInput;
    [SerializeField] float leftAndRightMultiplier = 2;

    [SerializeField] Rigidbody rb;

    public float speedIncreasePerPoint = 0.1f;
    bool isAlive = true;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
 
    private void FixedUpdate()
    {
        if (!isAlive) return;
        Vector3 forward = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 leftAndRight = transform.right * horizontalInput * speed * Time.fixedDeltaTime * leftAndRightMultiplier;
        rb.MovePosition(rb.position + forward + leftAndRight);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        isAlive = false;
        Invoke("Restart", 2);
        
    }
    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        //Check wether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2) + 0.01f, groundMask);
        
        //If we are on the ground, jump 
        rb.AddForce(Vector3.up * jumpForce);
    }
}
