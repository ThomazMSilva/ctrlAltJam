using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class NewClient : MonoBehaviour
    {
        public Texture desiredTexture;
        public Taste desiredTaste;

        public void CheckEnjoymentLevel(Texture tex, Taste tas)
        {
            int i = 0;
            if (tex == desiredTexture) i++;
            if (tas == desiredTaste) i++;

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
        private void OnMouseDown()
        {
            CheckEnjoymentLevel(DrinkManager.GetTexture(), DrinkManager.GetTaste());
        }
    }
}