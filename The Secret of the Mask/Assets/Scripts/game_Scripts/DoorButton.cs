using System.Collections;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] OpenDoor door;
    bool playerInRange;
    bool doorOpened;
    [SerializeField] GameObject interactText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            //door.SetActive(false);
            interactText.SetActive(false);
            door.open = true;
            FindFirstObjectByType<AudioManager>().CreateSound(AudioManager.audioType.Door, transform.position);
            FindFirstObjectByType<AudioManager>().CreateSound(AudioManager.audioType.ButtonPress, transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if (!doorOpened)
            {
                interactText.SetActive(true);
            }
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!doorOpened)
            {
                interactText.SetActive(false);
            }
            playerInRange = false;
        }
    }
}
