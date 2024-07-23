using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class NewClient : MonoBehaviour, IDataHandler
    {
        public CharactersManager characterManager;
        public CharacterKey charaterName;
        public Texture desiredTexture;
        public Taste desiredTaste;
        public int proximityLevel = 0;

        public void CheckEnjoymentLevel(Texture tex, Taste tas)
        {
            int i = 0;
            if (tex == desiredTexture) i++;
            if (tas == desiredTaste) i++;

            characterManager.characterList.TryGetValue(charaterName, out int charCurrLevel);

            characterManager.ChangeProximityLevel(charaterName, charCurrLevel + i);

            switch (i)
            {
                case 0:
                    Debug.Log("Uma merda. Eu abomino você e seus pares, e jamais respirarei os ares de sua cólera novamente.");
                    break;

                case 1:
                    Debug.Log
                    (
                        "Quase! " +
                        "Sinto que você ignorou alguma coisa que eu falei, mas ta valendo. " +
                        "Não quero vomitar."
                    );
                    break;

                case 2:
                    Debug.Log
                    (
                        "Vós sois o ídolo de bronze no templo de minha impotência. " +
                        "Curvo-me humildemente, e aguardo a penitência."
                    );
                    break;
            }
        }

        public void LoadData(SavedData data)
        {
            throw new System.NotImplementedException();
        }

        public void SaveData(ref SavedData data)
        {
            throw new System.NotImplementedException();
        }

        private void OnMouseDown()
        {
            CheckEnjoymentLevel(DrinkManager.GetTexture, DrinkManager.GetTaste);
        }
    }
}