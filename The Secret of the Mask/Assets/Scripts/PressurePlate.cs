using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public enum MaskType
    {
        topLeft,
        topCenter,
        topRight,
        middleLeft,
        middleCenter,
        middleRight,
        bottomLeft,
        bottomCenter,
        bottomRight
    }
    [SerializeField] MaskType maskType;
    [SerializeField] LayerMask maskLayer;

    bool enabled;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enabled)
        {
            /*RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2f, maskLayer))
            {
                Debug.Log("Pressure plate activated by " + hit.collider.name);
                // Add logic for when the pressure plate is activated
                CheckMask(hit.transform.GetComponent<MaskCubesSprites>().maskType);
            }*/
        }
    }

    void CheckMask(MaskCubesSprites.MaskType mask)
    {
        if(maskType.ToString() == mask.ToString())
        {
            spriteRenderer.color = Color.green;
            enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 2f, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enabled && other.transform.tag == "Mask")
        {
            Debug.Log("Pressure plate activated by " + other.transform.name);
            // Add logic for when the pressure plate is activated
            CheckMask(other.transform.GetComponent<MaskCubesSprites>().maskType);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (enabled && other.transform.tag == "Mask")
        {
            spriteRenderer.color = Color.white;
            enabled = false;
        }
            // Optional: Logic for when the object leaves the pressure plate
    }
}
