using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class RecipeBook : MonoBehaviour, ISavable
    {
        public GameObject[] drinkPrefabs;
        public GameObject[] drinksInRecipeBook;
        public bool[] drinkStates;

        public void UnlockDrink(int drinkIndex)
        {
            if (drinkIndex < drinksInRecipeBook.Length)
            {
                drinksInRecipeBook[drinkIndex].SetActive(true);
                drinkStates[drinkIndex] = true;
            }
            else { Debug.Log("Tentando ativar uma bebida de índice não-presente no array 'Drinks' do livro de receitas"); }

        }

        public void ActivateSavedDrinks()
        {
            for (int i = 0; i < drinksInRecipeBook.Length; i++)
            {
                drinksInRecipeBook[i].SetActive(drinkStates[i]);
            }
        }

        public void LoadData(SavedData data)
        {
            drinksInRecipeBook = data.savedDrinks;
            drinkStates = data.drinkStates;
            ActivateSavedDrinks();
        }

        public void SaveData(ref SavedData data)
        {
            data.savedDrinks = drinksInRecipeBook;
            data.drinkStates = drinkStates;
        }
    }
}