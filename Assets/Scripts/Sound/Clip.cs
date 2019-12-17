using UnityEngine;

[System.Serializable]
public class Clip
{
    public AudioClip audioClip;

    [HideInInspector]
    public AudioSource source;

    public string name;

    [Range(0.0f, 1.0f)]
    public float volume;

    public bool loop;
}
