using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public IngredientProperties properties;

    public Drink currentDrink;

    private DrinkProperties ingredientValues;

    private void Awake()
    {
        ingredientValues = properties.flavourValues;
    }

    private void OnMouseDown()
    {
        InteractWithIngredient();
    }

    public void InteractWithIngredient()
    {
        currentDrink.AddFlavour(ingredientValues);
    }
}
