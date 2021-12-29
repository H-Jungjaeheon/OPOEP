using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SoundClip
{
    public string SongName;
    public AudioClip clip;
}
public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioSource;
    public AudioSource audioSE;
    public List<SoundClip> clips = new List<SoundClip>();
    protected SoundManager() { }

    public void ChangeClip(string name, bool loop)
    //SoundManager.Instance.ChangeClip("Name",bool - true / false)
    {
        SoundClip find = clips.Find((o) => { return o.SongName == name; });
        if (find != null)
        {
            if (loop == true)
            {
                audioSource.Stop();
                audioSource.clip = find.clip;
                audioSource.loop = true;
                audioSource.Play();
            }
            else if (loop == false)
            {
                audioSE.clip = find.clip;
                audioSE.loop = false;
                audioSE.Play();

            }
        }
    }
    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
    public void SetSEVolume(float volume)
    {
        audioSE.volume = volume;
    }
}
