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
    }

    void CheckMask(MaskCubesSprites.MaskType mask)
    {
        if(maskType.ToString() == mask.ToString())
        {
            spriteRenderer.color = Color.green;
            enabled = true;
            FindFirstObjectByType<AudioManager>().CreateSound(AudioManager.audioType.PressurePlateActivated, transform.position);
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
