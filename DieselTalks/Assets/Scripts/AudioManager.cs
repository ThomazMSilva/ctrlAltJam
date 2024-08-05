using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class AudioManager : MonoBehaviour//, ISavable
    {
        [Space(8f), Header("AudioSources"), Space(5f)]
        public AudioSource sfxAudioSource;
        [SerializeField] AudioSource musicAudioSource;
        public AudioSource voicesAudioSource;
        
        [Space(8f), Header("Sliders"), Space(5f)]
        [SerializeField] Slider sfxSlider;
        [SerializeField] Slider musicSlider;
        [SerializeField] Slider voicesSlider;
        [SerializeField] Slider generalSlider;

        private void Start()
        {
            sfxSlider.onValueChanged.AddListener(delegate { SetSFX(); });
            musicSlider.onValueChanged.AddListener(delegate { SetMusic(); });
            voicesSlider.onValueChanged.AddListener(delegate { SetVoices(); });
            generalSlider.onValueChanged.AddListener(delegate { SetGeneral(); });

            InitializePlayerPrefs();
        }

        private void InitializePlayerPrefs()
        {
            if (!PlayerPrefs.HasKey("SFX"))
                PlayerPrefs.SetFloat("SFX", 0.5f);
            else
            {
                float vol = PlayerPrefs.GetFloat("SFX");
                sfxSlider.value = vol;
                sfxAudioSource.volume = vol;
            }


            if (!PlayerPrefs.HasKey("Music"))
                PlayerPrefs.SetFloat("Music", 0.5f);
            else
            {
                float vol = PlayerPrefs.GetFloat("Music");
                musicSlider.value = vol;
                musicAudioSource.volume = vol;
            }


            if (!PlayerPrefs.HasKey("Voices"))
                PlayerPrefs.SetFloat("Voices", 0.5f);
            else
            {
                float vol = PlayerPrefs.GetFloat("Voices");
                voicesSlider.value = vol;
                voicesAudioSource.volume = vol;
            }


            if (!PlayerPrefs.HasKey("General"))
                PlayerPrefs.SetFloat("General", 0.5f);
            else
            {
                float vol = PlayerPrefs.GetFloat("General");
                generalSlider.value = vol;
                AudioListener.volume = vol;
            }
        }

        public void SetVolume()
        {
            PlayerPrefs.SetFloat("SFX", sfxSlider.value);
            PlayerPrefs.SetFloat("Music", musicSlider.value);
            PlayerPrefs.SetFloat("Voices", voicesSlider.value);
            PlayerPrefs.SetFloat("General", generalSlider.value);
            /*sfxAudioSource.volume = sfxSlider.value;
            musicAudioSource.volume = musicSlider.value;
            voicesAudioSource.volume = voicesSlider.value;
            AudioListener.volume = generalSlider.value;*/
        }

        public void SetSFX() => sfxAudioSource.volume = sfxSlider.value;
        public void SetMusic() => musicAudioSource.volume = musicSlider.value;
        public void SetVoices() => voicesAudioSource.volume = voicesSlider.value;
        public void SetGeneral() => AudioListener.volume = generalSlider.value;

        /*public void LoadData(SavedData data)
        {
            AudioListener.volume = data.generalVolume;
            sfxSlider.value = data.sfxVolume;
            musicSlider.value = data.musicVolume;
            voicesSlider.value = data.voicesVolume;
            SetVolume();
        }

        public void SaveData(ref SavedData data)
        {
            data.generalVolume = AudioListener.volume;
            data.sfxVolume = sfxSlider.value;
            data.musicVolume = musicSlider.value;
            data.voicesVolume = voicesSlider.value;
        }*/

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