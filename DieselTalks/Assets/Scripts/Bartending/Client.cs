using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class Client : MonoBehaviour
    {
        
        public CharacterKey charaterName;
        public Texture desiredTexture;
        public Taste desiredTaste;
        
        private int charCurrLevel;
        public int minimumProximityLevel = 0;
        
        public GameObject responsesParent;
        private GameObject[] responses = new GameObject[3];
        private CharacterManager characterManager;

        public void ChangeEnjoymentLevel(Texture tex, Taste tas)
        {
            int i = 0;
            if (tex == desiredTexture) i++;
            if (tas == desiredTaste) i++;

            //Debug.Log(characterManager.characterList.TryGetValue(charaterName, out int a));
            characterManager.characterList.TryGetValue(charaterName, out charCurrLevel);

            characterManager.ChangeProximityLevel(charaterName, charCurrLevel + i);

            responses[i].SetActive(true);
            /*switch (i)
            {
                case 0:
                    Debug.Log("Uma merda. Eu abomino você e seus pares, e jamais respirarei os ares de sua cólera novamente.");
                    //badResponse.SetActive(true);
                    break;

                case 1:
                    Debug.Log
                    (
                        "Quase! " +
                        "Sinto que você ignorou alguma coisa que eu falei, mas ta valendo. " +
                        "Não quero vomitar."
                    );
                    //neutralResponse.SetActive(true);
                    break;

                case 2:
                    Debug.Log
                    (
                        "Vós sois o ídolo de bronze no templo de minha impotência. " +
                        "Curvo-me humildemente, e aguardo a penitência."
                    );
                    //goodResponse.SetActive(true);
                    break;
            }*/
        }

        private void Awake()
        {
            characterManager = GameManager.Instance.CharacterManager;
            
            for (int i = 0; i < responsesParent.transform.childCount; i++) 
                responses[i] = responsesParent.transform.GetChild(i).gameObject;
        }

        private void OnEnable()
        {
            if (charCurrLevel < minimumProximityLevel)
            {
                Debug.Log($"O nivel de proximidade com {gameObject.name} nao era suficiente pra esse nivel. Passando pro próximo.");
                GameManager.Instance.LevelManager.IncreaseLevel();
            }
        }
    }
}