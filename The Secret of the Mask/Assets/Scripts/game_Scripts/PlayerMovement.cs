using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float iceForce;
    Rigidbody rb;

    float horizontalInput;
    float verticalInput;

    bool isOnIce;

    Vector3 checkpoint;

    [SerializeField] float iceSkatingSoundInterval;
    float iceSkatingSoundTimer;

    bool grounded;
    bool maskInRange;
    bool maskPulled;

    Transform maskCube;

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
        if(maskInRange && maskPulled)
        {
            PullMask();
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (!grounded)
        {
            rb.AddForce(Physics.gravity * rb.mass);
        }

        if (verticalInput != 0 && grounded)
        { 
            MovePlayer();
        }
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        maskPulled = Input.GetKey(KeyCode.E);
    }

    void MovePlayer()
    {
        if(isOnIce)
        {
            rb.AddForce(transform.forward * iceForce * Time.fixedDeltaTime, ForceMode.Acceleration);
            iceSkatingSoundTimer -= Time.fixedDeltaTime;
            if(iceSkatingSoundTimer <= 0f)
            {
                FindFirstObjectByType<AudioManager>().CreateSound(AudioManager.audioType.IceSkating, transform.position);
                iceSkatingSoundTimer = iceSkatingSoundInterval;
            }
        }
        else
        {
            rb.linearVelocity = (transform.forward * verticalInput * speed) * Time.fixedDeltaTime;
        }
    }

    void PullMask()
    {
        Debug.Log("Mask pulled");
        maskCube.GetComponent<Rigidbody>().AddForce((transform.position - maskCube.position).normalized * speed * 2f * Time.deltaTime, ForceMode.Acceleration);
    }

    void RotatePlayer()
    {
        transform.Rotate(rotationSpeed * Vector3.up * horizontalInput * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Ice")
        {
            isOnIce = true;
        }
        if(other.transform.tag == "Lava")
        {
            FindFirstObjectByType<Lava>().isGrowing = true;
        }
        if(other.transform.tag == "Mask")
        {
            maskInRange = true;
            maskCube = other.transform;
            Debug.Log("Mask in range" );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Checkpoint")
        {
            checkpoint = other.transform.position;
        }
        if (other.transform.tag == "DeathZone")
        {
            transform.position = checkpoint;
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Ice")
        {
            isOnIce = false;
        }
        if (other.transform.tag == "Lava")
        {
            FindFirstObjectByType<Lava>().isGrowing = false;
        }
        if (other.transform.tag == "Mask")
        {
            maskInRange = false;
        }
    }
}
