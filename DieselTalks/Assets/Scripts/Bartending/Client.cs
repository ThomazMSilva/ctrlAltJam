using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class Client : MonoBehaviour
    {
        public CharacterManager characterManager;
        public CharacterKey charaterName;
        public Texture desiredTexture;
        public Taste desiredTaste;
        public int proximityLevel = 0;
        public GameObject
            badResponse,
            neutralResponse,
            goodResponse;

        public void CheckEnjoymentLevel(Texture tex, Taste tas)
        {
            int i = 0;
            if (tex == desiredTexture) i++;
            if (tas == desiredTaste) i++;

            Debug.Log(characterManager.characterList.TryGetValue(charaterName, out int a));
            characterManager.characterList.TryGetValue(charaterName, out int charCurrLevel);

            characterManager.ChangeProximityLevel(charaterName, charCurrLevel + i);

            switch (i)
            {
                case 0:
                    Debug.Log("Uma merda. Eu abomino você e seus pares, e jamais respirarei os ares de sua cólera novamente.");
                    badResponse.SetActive(true);
                    break;

                case 1:
                    Debug.Log
                    (
                        "Quase! " +
                        "Sinto que você ignorou alguma coisa que eu falei, mas ta valendo. " +
                        "Não quero vomitar."
                    );
                    neutralResponse.SetActive(true);
                    break;

                case 2:
                    Debug.Log
                    (
                        "Vós sois o ídolo de bronze no templo de minha impotência. " +
                        "Curvo-me humildemente, e aguardo a penitência."
                    );
                    goodResponse.SetActive(true);
                    break;
            }
        }

        private void Awake()
        {
            characterManager = FindObjectOfType<CharacterManager>();
        }

        private void OnMouseDown()
        {
            CheckEnjoymentLevel(DrinkManager.GetTexture, DrinkManager.GetTaste);
        }
    }
}