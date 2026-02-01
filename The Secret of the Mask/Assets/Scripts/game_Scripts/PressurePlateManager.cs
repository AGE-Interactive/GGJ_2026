using UnityEngine;

public class PressurePlateManager : MonoBehaviour
{
    bool maskCompleted = false;
    int activeMasks = 0;
    [SerializeField] Transform maskParent;

    public void ActivatePlate()
    {
        activeMasks++;
        if(activeMasks >= 9 && !maskCompleted)
        {
            maskCompleted = true;
            FindFirstObjectByType<AudioManager>().CreateSound(AudioManager.audioType.MaskCompleted, transform.position);
            CreateMask();
        }
    }

    public void DeactivatePlate()
    {
        if(activeMasks > 0)
        {
            activeMasks--;
        }
    }

    void CreateMask()
    {
        maskParent.GetChild(0).transform.position = transform.position + new Vector3(-1f, 0 , 1f);
        maskParent.GetChild(1).transform.position = transform.position + new Vector3(0f, 0 , 1f);
        maskParent.GetChild(2).transform.position = transform.position + new Vector3(1f, 0 , 1f);
        maskParent.GetChild(3).transform.position = transform.position + new Vector3(-1f, 0 , 0f);
        maskParent.GetChild(4).transform.position = transform.position + new Vector3(0f, 0 , 0f);
        maskParent.GetChild(5).transform.position = transform.position + new Vector3(1f, 0 , 0f);
        maskParent.GetChild(6).transform.position = transform.position + new Vector3(-1f, 0 , -1f);
        maskParent.GetChild(7).transform.position = transform.position + new Vector3(0f, 0 , -1f);
        maskParent.GetChild(8).transform.position = transform.position + new Vector3(1f, 0 , -1f);

        for (int i = 0; i < maskParent.childCount; i++)
        {
            maskParent.GetChild(i).transform.eulerAngles = new Vector3(0f, 0f, 0f);
            maskParent.GetChild(i).GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
