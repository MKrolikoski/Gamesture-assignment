using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Clip[] clips;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;

        foreach (Clip clip in clips)
        {
            clip.source = gameObject.AddComponent<AudioSource>();
            clip.source.clip = clip.audioClip;
            clip.source.volume = clip.volume;
            clip.source.loop = clip.loop;
            //Set clip to be 2D
            clip.source.spatialBlend = 0.0f;
        }
    }

    public void PlayClip(string clipName)
    {
        Clip clip = Array.Find(clips, c => c.name.Equals(clipName));
        clip?.source.Play();
    }

    public void StopClip(string clipName)
    {
        Clip clip = Array.Find(clips, c => c.name.Equals(clipName));
        clip?.source.Stop();
    }
  
}
