using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] float scaleSpeed = 0.5f;
    Vector3 initialScale;
    public bool isGrowing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrowing)
        {
            transform.localScale += new Vector3(0, scaleSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.localScale = initialScale;
        }
    }
}
