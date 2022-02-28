using UnityEngine;
using System;
using UnityEngine.Audio;

namespace Purgatory
{
    public class Audio : MonoBehaviour
    {   
        [SerializeField] private Sound[] sounds;
        [SerializeField] private AudioMixerGroup musicMixerGroup;
        [SerializeField] private AudioMixerGroup soundEffectsMixerGroup;

        private void Awake()
        {
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.loop = s.loop;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;

                switch (s.audioType)
                {
                    case Sound.AudioType.soundEffect:
                        s.source.outputAudioMixerGroup = soundEffectsMixerGroup;
                        break;
                    case Sound.AudioType.music:
                        s.source.outputAudioMixerGroup = musicMixerGroup;
                        break;
                    default:
                        break;
                }
            }

           
        }

        private void Start()
        {
            Play("Environment");
        }

        public void Play(string name)
        {
            Sound s =  Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }

        public void StopPlaying(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Stop();
        }

        public void PlayOneShot(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.PlayOneShot(s.clip);
        }

        public void UpdateMixerVolume()
        {
            musicMixerGroup.audioMixer.SetFloat("MyMusic",Mathf.Log10(AudioOptions.musicVolume) * 20);   //convert into decibels
            soundEffectsMixerGroup.audioMixer.SetFloat("MySounds",Mathf.Log10(AudioOptions.soundEffectsVolume) * 20);  
        }
    }
}
