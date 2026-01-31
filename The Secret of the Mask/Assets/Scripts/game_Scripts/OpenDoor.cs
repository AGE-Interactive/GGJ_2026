using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] float openSpeed = 2f;
    [SerializeField] float openAmount;
    Vector3 initialPosition;
    public bool open;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition + new Vector3(0, openAmount, 0), openSpeed * Time.deltaTime);
        }
    }
}
