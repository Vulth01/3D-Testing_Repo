using UnityEngine.Audio;
using UnityEngine;
using System;


public class audioManagerScript : MonoBehaviour
{
    public static audioManagerScript instance;
    public AudioMixerGroup mixerGroup;
    public SoundClass[] sounds;

   
    void Awake()
    {
    
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (SoundClass s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }
    
   public void Play (string clipname)
    {
        
      SoundClass s=  Array.Find(sounds, SoundClass => SoundClass.clipName == clipname);
        if (s == null)
        {
            Debug.LogWarning("Clip Name " + clipname + " not found");
            return;
        }
       
        s.source.Play();
       // s.source.mute = true;
    }
    void Start()
    {
        Play("BassSynthy"); //for the themesong
    }

}
[System.Serializable]
public class SoundClass
{
    public string clipName;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    [HideInInspector]
    public AudioSource source;


}
