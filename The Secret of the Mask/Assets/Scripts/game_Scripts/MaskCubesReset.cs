using UnityEngine;

public class MaskCubesReset : MonoBehaviour
{
    Vector3 initialPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "DeathZone")
        {
            transform.position = initialPosition;
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }
}
