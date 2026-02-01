using UnityEngine;

public class MaskCubesSounds : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float soundInterval = 0.5f;
    float lastSoundTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastSoundTime = soundInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.linearVelocity.magnitude > 0.1f)
        {
            lastSoundTime -= Time.fixedDeltaTime;
            if (lastSoundTime <= 0f)
            {
                FindFirstObjectByType<AudioManager>().CreateSound(AudioManager.audioType.MoveBlock, transform.position);
                lastSoundTime = soundInterval;
            }
        }
    }
}
