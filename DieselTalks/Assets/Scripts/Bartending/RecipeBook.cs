using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class RecipeBook : MonoBehaviour, ISavable
    {
        public GameObject[] drinks;
        public bool[] drinkStates;

        public void ActivateDrink(int drinkIndex)
        {
            if (drinkIndex < drinks.Length)
            {
                drinks[drinkIndex].SetActive(true);
                drinkStates[drinkIndex] = true;
            }
            else
            {
                Debug.Log("Tentando ativar uma bebida de índice não-presente no array 'Drinks' do livro de receitas");
            }
        }

        public void ActivateSavedDrinks()
        {
            for (int i = 0; i < drinks.Length; i++)
            {
                drinks[i].SetActive(drinkStates[i]);
            }
        }

        public void LoadData(SavedData data)
        {
            drinks = data.savedDrinks;
            drinkStates = data.drinkStates;
            ActivateSavedDrinks();
        }

        public void SaveData(ref SavedData data)
        {
            data.savedDrinks = drinks;
            data.drinkStates = drinkStates;
        }
    }
}