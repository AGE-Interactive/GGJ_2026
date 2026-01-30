using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    Rigidbody rb;

    float horizontalInput;
    float verticalInput;
    float targetRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }

    void MovePlayer()
    {
        rb.linearVelocity = (transform.forward * verticalInput * speed) * Time.fixedDeltaTime;
    }

    void RotatePlayer()
    {
        transform.Rotate(rotationSpeed * Vector3.up * horizontalInput * Time.deltaTime);
    }
}
