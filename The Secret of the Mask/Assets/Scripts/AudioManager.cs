using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum audioType
    {
        Music,
        SFX,
        Ambient
    }  

    [SerializeField] SoundType[] soundType;
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] AudioSource musicSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(audioType type)
    {
        switch(type)
        {
            case audioType.Music:
                // Play music sound
                break;
            case audioType.SFX:
                // Play SFX sound
                break;
            case audioType.Ambient:
                // Play ambient sound
                break;
            default:
                break;
        }
    }
}
