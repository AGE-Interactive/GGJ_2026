using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum audioType
    {
        Door,
        MoveBlock,
        PressurePlateActivated,
        MaskCompleted,
        IceSkating,
        ButtonPress
    }  

    [SerializeField] SoundType[] soundType;
    [SerializeField] AudioClip backgroundMusic;
    public AudioSource musicSource;
    [SerializeField] GameObject audioObjectPrefab;

    public AudioSource lavaAmbient;
    public AudioSource iceAmbient;
    public AudioSource laserAmbient;

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

    public void CreateSound(audioType type, Vector3 soundLocation)
    {
        AudioSource audioObjectSource;
        switch (type)
        {
            case audioType.Door:
                audioObjectSource = Instantiate(audioObjectPrefab, soundLocation, Quaternion.identity).GetComponent<AudioSource>();
                PlaySound(soundType[0], audioObjectSource);
                break;
            case audioType.PressurePlateActivated:
                audioObjectSource = Instantiate(audioObjectPrefab, soundLocation, Quaternion.identity).GetComponent<AudioSource>();
                PlaySound(soundType[1], audioObjectSource);
                break;
            case audioType.IceSkating:
                audioObjectSource = Instantiate(audioObjectPrefab, soundLocation, Quaternion.identity).GetComponent<AudioSource>();
                PlaySound(soundType[2], audioObjectSource);
                break;
            case audioType.MoveBlock:
                audioObjectSource = Instantiate(audioObjectPrefab, soundLocation, Quaternion.identity).GetComponent<AudioSource>();
                PlaySound(soundType[3], audioObjectSource);
                break;
            case audioType.MaskCompleted:
                audioObjectSource = Instantiate(audioObjectPrefab, soundLocation, Quaternion.identity).GetComponent<AudioSource>();
                PlaySound(soundType[4], audioObjectSource);
                break;
            case audioType.ButtonPress:
                audioObjectSource = Instantiate(audioObjectPrefab, soundLocation, Quaternion.identity).GetComponent<AudioSource>();
                PlaySound(soundType[5], audioObjectSource);
                break;
        }
    }

    void PlaySound(SoundType sound, AudioSource audioObjectSource)
    {
        audioObjectSource.clip = sound.clip[Random.Range(0, sound.clip.Length)];
        audioObjectSource.volume = sound.volume;
        audioObjectSource.pitch = sound.pitch;
        audioObjectSource.Play();
        Destroy(audioObjectSource.gameObject, audioObjectSource.clip.length);
    }
}
