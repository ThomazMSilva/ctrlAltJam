﻿using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class Client : MonoBehaviour
    {
        
        public CharacterKey charaterName;
        public Texture desiredTexture;
        public Taste desiredTaste;
        
        private int charCurrLevel;
        public int minProximityLevel2ShowUp = 0;
        public int minProximityLevel2Snitch = 4;
        
        public GameObject responsesParent;
        private GameObject[] responses = new GameObject[3];
        public GameObject[] secretResponse;
        private CharacterManager characterManager;
        public bool ultimaFase = false;
        //private bool correctTexture = false, correctTaste = false;
        private int i = 0;

        public void ChangeEnjoymentLevel(Texture tex, Taste tas)
        {
            if (tex == desiredTexture) 
            {
                //correctTexture = true;
                i++; 
            }
            if (tas == desiredTaste) 
            { 
                //correctTaste = true;
                i++; 
            }

            //Debug.Log(characterManager.characterList.TryGetValue(charaterName, out int a));
            characterManager.characterList.TryGetValue(charaterName, out charCurrLevel);

            characterManager.ChangeProximityLevel(charaterName, charCurrLevel + i);

            if (!ultimaFase)
            {
                responses[i].SetActive(true);
                return;
            }

            if (charCurrLevel >= minProximityLevel2Snitch)
            {
                secretResponse[i].SetActive(true);
            }
            else responses[i].SetActive(true);
        }

        public void CheckSecret()
        {
            characterManager.characterList.TryGetValue(charaterName, out charCurrLevel);
            if (charCurrLevel >= minProximityLevel2Snitch)
                secretResponse[i].SetActive(true);
            else GameManager.Instance.LevelManager.IncreaseLevel();
        }

        private void Awake()
        {
            characterManager = GameManager.Instance.CharacterManager;

            if (responsesParent.transform.childCount > 3)
            {
                Debug.LogError
                (
                    $"Objeto {responsesParent.name} tem mais de 3 respostas possíveis como seus objetos filhos." +
                    $" Tira um ai jao, n pode." +
                    $"Isso é de onde o script Client do {gameObject.name} ta pegando as respostas boa media e ruim, fala cmg " +
                    $"-Biqueta de Propano"
                );
                return;
            }
            
            for (int i = 0; i < responsesParent.transform.childCount; i++) 
                responses[i] = responsesParent.transform.GetChild(i).gameObject;
        }

        private void OnEnable()
        {
            if (charCurrLevel < minProximityLevel2ShowUp)
            {
                Debug.Log($"O nivel de proximidade com {gameObject.name} nao era suficiente pra esse nivel. Passando pro próximo.");
                GameManager.Instance.LevelManager.IncreaseLevel();
            }
        }
    }
}