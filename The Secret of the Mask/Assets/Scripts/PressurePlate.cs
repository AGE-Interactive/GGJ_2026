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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!enabled)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.up, out hit, 0.5f, maskLayer))
            {
                Debug.Log("Pressure plate activated by " + hit.collider.name);
                // Add logic for when the pressure plate is activated
                CheckMask(hit.transform.GetComponent<MaskCubesSprites>().maskType);
            }
        }
    }

    void CheckMask(MaskCubesSprites.MaskType mask)
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 0.5f, 0));
    }
}
