using UnityEngine;

public class SeeThrough : MonoBehaviour
{
    [SerializeField] Material seeThroughMaterial;
    Material originalMaterial;

    [SerializeField] Transform target;

    [SerializeField] LayerMask playerLayer;
    GameObject lastObjectHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(target.position, (transform.position - target.position).normalized, out hit, 500f, playerLayer))
        {
            if(hit.transform.GetComponent<Renderer>() == null)
            {
                return;
            }
            if(lastObjectHit != null)
            {
                lastObjectHit.GetComponent<Renderer>().material = originalMaterial;
            }
            lastObjectHit = hit.collider.gameObject;
            originalMaterial = lastObjectHit.GetComponent<Renderer>().material;
            lastObjectHit.GetComponent<Renderer>().material = seeThroughMaterial;
            seeThroughMaterial.color = new Color(originalMaterial.color.r, originalMaterial.color.g, originalMaterial.color.b, seeThroughMaterial.color.a);
        }
        else
        {   
            if(lastObjectHit != null)
            {
                lastObjectHit.GetComponent<Renderer>().material = originalMaterial;
                lastObjectHit = null;
            }
        }
    }
}
