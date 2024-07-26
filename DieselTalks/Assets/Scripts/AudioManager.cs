using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class AudioManager : MonoBehaviour, ISavable
    {
        [Space(8f), Header("AudioSources"), Space(5f)]
        public AudioSource sfxAudioSource;
        [SerializeField] AudioSource musicAudioSource;
        public AudioSource voicesAudioSource;
        
        [Space(8f), Header("Sliders"), Space(5f)]
        [SerializeField] Slider sfxSlider;
        [SerializeField] Slider musicSlider;
        [SerializeField] Slider voicesAudioSlider;
        [SerializeField] Slider generalSlider;

        public void SetVolume()
        {
            sfxAudioSource.volume = sfxSlider.value;
            musicAudioSource.volume = musicSlider.value;
            voicesAudioSource.volume = voicesAudioSlider.value;
            AudioListener.volume = generalSlider.value;
        }

        public void LoadData(SavedData data)
        {
            AudioListener.volume = data.generalVolume;
            sfxSlider.value = data.sfxVolume;
            musicSlider.value = data.musicVolume;
            voicesAudioSlider.value = data.voicesVolume;
            SetVolume();
        }

        public void SaveData(ref SavedData data)
        {
            data.generalVolume = AudioListener.volume;
            data.sfxVolume = sfxSlider.value;
            data.musicVolume = musicSlider.value;
            data.voicesVolume = voicesAudioSlider.value;
        }
    }
}