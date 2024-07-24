using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class DrinkMix : MonoBehaviour
    {
        public Texture drinkTexture;
        public Taste drinkTaste;
        public int drinkSensation { get; private set; }
        public RectTransform TextureCircle, TasteCircle;
        public Ingredient ingredientA, ingredientB;
        public RecipeBook recipeBook;

        public void SetIngredient(Ingredient ingr, RectTransform rect)
        {
            if (ingr.isBase)
            {
                if(ingredientA != null)Destroy(ingredientA.gameObject);
                drinkTexture = ingr.ingredientTexture;
                ingredientA = ingr;
                rect.anchoredPosition = TextureCircle.anchoredPosition;
            }
            else
            {
                if(ingredientB != null)Destroy(ingredientB.gameObject);
                drinkTaste = ingr.ingredientTaste;
                ingredientB = ingr;
                rect.anchoredPosition = TasteCircle.anchoredPosition;
            }
        }
        public void FinishDrink()
        {
            recipeBook.ActivateDrink(DrinkManager.GetEffectIndex(drinkTexture, drinkTaste));
        }
    }

}