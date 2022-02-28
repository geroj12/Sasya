using UnityEngine;


namespace Purgatory
{
    public class AudioOptions : MonoBehaviour
    {
        [SerializeField]private new Audio audio;

        public static float musicVolume { get; private set; }
        public static float soundEffectsVolume { get; private set; }

        public void OnMusicSliderValueChanged(float value)
        {
            musicVolume = value;
            audio.UpdateMixerVolume();
        }

        public void OnSoundSliderValueChanged(float value)
        {
            soundEffectsVolume = value;
            audio.UpdateMixerVolume();
        }
    }
}
