using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class NewIngredient : MonoBehaviour
    {
        public Texture ingredientTexture;
        public Taste ingredientTaste;
        public bool isBase;

        public void AddIngredient(NewDrink drink)
        {
            if (isBase) drink.drinkTexture = ingredientTexture;
            else drink.drinkTaste = ingredientTaste;
        }

        public void AddIngredient()
        {
            if (isBase)
            {
                Debug.Log($"Adicionando textura {ingredientTexture} ao drink :3");
                DrinkManager.SetCurrentDrinkTexture(ingredientTexture);
            }
            else
            {
                Debug.Log($"Adicionando gosto {ingredientTaste} ao drink Ò-Ó");
                DrinkManager.SetCurrentDrinkTaste(ingredientTaste);
            }
        }

        private void OnMouseDown()
        {
            AddIngredient();
        }
    }
}