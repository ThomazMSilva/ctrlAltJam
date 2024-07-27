using Assets.Scripts.Bartending;
using System.Collections;
using System.Data.SqlTypes;
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

        [Space(8f), Header("AudioClips"), Space(5f)]
        [SerializeField] AudioClip buttonClip;
        [SerializeField] AudioClip poppingClip;
        [SerializeField] AudioClip discardClip;
        [SerializeField] AudioClip deliverClip;
        [SerializeField] AudioClip[] textureClips;
        [SerializeField] AudioClip[] tasteClips;
        [SerializeField] AudioClip musicMenu;
        [SerializeField] AudioClip musicGame;

        public void SwitchMusic()
        {
            if (musicAudioSource.clip == musicMenu)
            { 
                musicAudioSource.clip = musicGame;
                musicAudioSource.Play();
            }
            else
            {
                musicAudioSource.clip = musicMenu;
                musicAudioSource.Play();
            }
        }

        public void PlayDiscardSound() => sfxAudioSource.PlayOneShot(discardClip);
        public void PlayDeliverSound() => sfxAudioSource.PlayOneShot(deliverClip);
        public void PlayPoppingSound() => sfxAudioSource.PlayOneShot(poppingClip);
        public void PlayTasteSound(int tasteIndex) => sfxAudioSource.PlayOneShot(tasteClips[tasteIndex]);
        public void PlayTextureSound(int textureIndex) => sfxAudioSource.PlayOneShot(textureClips[textureIndex]);
        public void PlayButtonEnterSound() => sfxAudioSource.PlayOneShot(buttonClip);
    }
}