using UnityEngine;

[System.Serializable]
public class SoundType
{
    public string name;
    public AudioManager.audioType type;
    public AudioClip[] clip;
    public float volume;
    public float pitch;
}
