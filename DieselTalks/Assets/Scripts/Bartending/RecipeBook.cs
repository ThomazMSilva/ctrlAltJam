using System.IO.IsolatedStorage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Bartending
{
    public class RecipeBook : MonoBehaviour, ISavable
    {
        public GameObject[] drinkPrefabs;
        public GameObject[] drinksInRecipeBook;
        [HideInInspector]public bool[] drinkStates;
        public GameObject recipeScreen;

        [Space(8f), Header("Descricao"), Space(5f)]
        [SerializeField] GameObject descriptionBackground;
        [SerializeField] Image drinkCurrentIMG;
        [SerializeField] TextMeshProUGUI drinkNameTMP;
        [SerializeField] TextMeshProUGUI drinkDescriptionTMP;

        [Space(8f)]

        [SerializeField] Sprite baseSprite;
        [SerializeField] Sprite[] drinkSprites;
        [SerializeField] string[] drinkNames;
        [SerializeField, TextArea] string[] drinkDescriptions;

        public void OpenDescription(GameObject go)
        {
            int index = 0;
            for (int i = 0; i < drinksInRecipeBook.Length; i++)
                if (go == drinksInRecipeBook[i]) { index = i; break; }

            drinkCurrentIMG.sprite = drinkSprites[index] ?? baseSprite;
            drinkNameTMP.text = drinkNames[index] ?? "";
            drinkDescriptionTMP.text = drinkDescriptions[index] ?? "";
            
            descriptionBackground.SetActive(true);
        }


        /*private void Awake()
        {
            for (int i = 0; i < drinksInRecipeBook.Length; i++)            
                if (drinksInRecipeBook[i].TryGetComponent<UnlockedDrink>(out var unlocked))                
                    unlocked.index = i;
                
            
        }*/

        public string DrinkStateString()
        {
            string s = "";
            for (int i = 0; i < drinkPrefabs.Length; i++)
            {
                s += $"{drinksInRecipeBook[i].name}: {drinkStates[i]}\n";
            }
            return s;
        }

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
            //Debug.Log("Activate no start");
            for (int i = 0; i < drinksInRecipeBook.Length; i++)
                drinksInRecipeBook[i].SetActive(drinkStates[i]);
        }

        public void LoadData(SavedData data)
        {
            drinkStates = data.drinkStates;
            ActivateSavedDrinks();
            //Debug.Log("Load:\n" + str);
        }
        //string str = "";
        public void SaveData(ref SavedData data)
        {
            data.drinkStates = new bool[drinkStates.Length];
            //str = "";
            for (int i = 0; i < drinksInRecipeBook.Length; i++)
            {
                data.drinkStates[i] = drinksInRecipeBook[i].activeSelf;
                //str += $"{drinksInRecipeBook[i]}: data.drinksStates - {data.drinkStates[i]}\n";
            }
            //Debug.Log("Salvou:\n" + str);
        }
    }
}