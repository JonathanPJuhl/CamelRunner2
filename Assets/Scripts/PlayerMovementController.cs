using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 10;
    float horizontalInput;
    public float leftAndRightMultiplier = 2;

    public Rigidbody rb;

    // public float speedIncreasePerPoint = 500f;
    bool isAlive = true;
    bool hide = false;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject restartButton;

    private void Start()
    {
        gameOver.SetActive(hide);
        restartButton.SetActive(hide);
    }

    private void FixedUpdate()
    {
        if (!isAlive) return;
        Vector3 forward = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 leftAndRight = transform.right * horizontalInput * speed * Time.fixedDeltaTime * leftAndRightMultiplier;
        rb.MovePosition(rb.position + forward + leftAndRight);
    }

    void Update()
    {
        if (!isAlive) return;
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
        gameOver.SetActive(!hide);
        restartButton.SetActive(!hide);
        isAlive = false;
        //Invoke("Restart", 2);
        
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        
        //Check wether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2) + 0.01f, groundMask);
        
        //If we are on the ground, jump 
        if (rb.transform.position.y >= 1.5)
        {
            return;
        }
        rb.AddForce(Vector3.up * jumpForce);
    }
}
