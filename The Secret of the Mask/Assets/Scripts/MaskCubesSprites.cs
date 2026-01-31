using UnityEngine;

public class MaskCubesSprites : MonoBehaviour
{
    [SerializeField] Sprite maskSprite;
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
    public MaskType maskType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*switch (maskType)
        {
            case MaskType.topLeft:
                for(int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();
                    if (childSpriteRenderer != null)
                    {
                        childSpriteRenderer.sprite = maskSprite;
                    }
                }
                break;
                case MaskType.topCenter:
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();
                    if (childSpriteRenderer != null)
                    {
                        childSpriteRenderer.sprite = maskSprite;
                    }
                }
                break;
            case MaskType.topRight:
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();
                    if (childSpriteRenderer != null)
                    {
                        childSpriteRenderer.sprite = maskSprite;
                    }
                }
                break;
        }*/

        AssignMaskSpriteToChildren();
    }

    void AssignMaskSpriteToChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();
            if (childSpriteRenderer != null)
            {
                childSpriteRenderer.sprite = maskSprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
