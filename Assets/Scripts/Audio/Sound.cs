using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{

    public string name;

    [SerializeField]
    AudioClip clip = null;

    [SerializeField, Range(0f, 1f)]
    float volume = .75f;
    [SerializeField, Range(0f, 1f)]
    float volumeVariance = .1f;

    [SerializeField, Range(.1f, 3f)]
    float pitch = 1f;
    [SerializeField, Range(0f, 1f)]
    float pitchVariance = .1f;

    [SerializeField]
    bool loop = false;

    [SerializeField]
    AudioMixerGroup mixerGroup = null;

    [HideInInspector]
    AudioSource source = null;


    public void Awake(GameObject owner, AudioMixerGroup mixerGroup)
    {
        source = owner.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = mixerGroup;
    }

    public void Play()
    {
        if (this.mixerGroup)
        {
            source.outputAudioMixerGroup = this.mixerGroup;
        }
        source.clip = clip;
        source.loop = loop;
        source.volume = volume * (1f + UnityEngine.Random.Range(-volumeVariance / 2f, volumeVariance / 2f));
        source.pitch = pitch * (1f + UnityEngine.Random.Range(-pitchVariance / 2f, pitchVariance / 2f));
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}
