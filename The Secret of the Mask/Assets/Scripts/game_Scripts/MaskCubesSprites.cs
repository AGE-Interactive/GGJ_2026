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
}
