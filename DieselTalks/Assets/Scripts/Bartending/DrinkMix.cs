using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class DrinkMix : MonoBehaviour
    {
        public Texture drinkTexture;
        public Taste drinkTaste;
        public int drinkSensation { get; private set; }

        [SerializeField] private int chancesLeft = 3;

        [SerializeField] 
        private RectTransform 
            TextureCircle, 
            TasteCircle;
        
        private Ingredient 
            ingredientA,
            ingredientB;
        
        //[SerializeField] RecipeBook recipeBook;
        [SerializeField] ClientManager clientManager;
        [SerializeField] UIManager menuManager;

        [SerializeField] GameObject
            buttons;
        [SerializeField] Transform drinkFinalPosition;

        private GameObject drink;
        private RecipeBook book;

        private void Start()
        {
            book = GameManager.Instance.recipeBook;
        }

        public void SetIngredient(Ingredient ingr, RectTransform rect)
        {
            if (ingr.isBase)
            {
                if(ingredientA != null)
                    Destroy(ingredientA.gameObject);

                drinkTexture = ingr.ingredientTexture;
                ingredientA = ingr;
                rect.anchoredPosition = TextureCircle.anchoredPosition;

                GameManager.Instance.AudioManager.PlayTextureSound((int)ingr.ingredientTexture);
            }
            else
            {
                if(ingredientB != null)
                    Destroy(ingredientB.gameObject);

                drinkTaste = ingr.ingredientTaste;
                ingredientB = ingr;
                rect.anchoredPosition = TasteCircle.anchoredPosition;

                GameManager.Instance.AudioManager.PlayTasteSound((int)ingr.ingredientTaste);
            }
        }

        public void EmptyCircle(Ingredient ingredient)
        {
            if (ingredient == ingredientA)
            {
                Destroy(ingredientA.gameObject);
                ingredientA = null;
            }
            else if (ingredient == ingredientB)
            {
                Destroy(ingredientB.gameObject);
                ingredientB = null;
            }
            else { Debug.Log($"Ocorreu algum erro tentando destruir o ingrediente {ingredient.name}."); }

        }

        public void FinishDrink()
        {
            if (ingredientA == null || ingredientB == null)
            {
                Debug.Log("Algum ingrediente ta faltando ==333333");
                return;
            }
            EmptyCircle(ingredientA);
            EmptyCircle(ingredientB);

            int i = DrinkManager.GetEffectIndex(drinkTexture, drinkTaste);

            drink = Instantiate(book.drinkPrefabs[i], buttons.transform);

            buttons.SetActive(true);
        }

        public void DiscardDrink()
        {
            if (chancesLeft <= 0) return;

            chancesLeft--;
            
            Destroy(drink);

            GameManager.Instance.AudioManager.PlayDiscardSound();

            drink = null;
            buttons.SetActive(false);

        }

        public void DeliverDrink()
        {
            int i = DrinkManager.GetEffectIndex(drinkTexture, drinkTaste);
            book.UnlockDrink(i);

            GameManager.Instance.AudioManager.PlayDeliverSound();
            //StartCoroutine(DragDrinkFinalPosition(drink));
            drink.transform.SetParent(drinkFinalPosition, false);
            drink.transform.localPosition = Vector2.zero;
            clientManager.ChangeClientEnjoymentLevel();
            menuManager.SwitchBrewingScreen();
            buttons.SetActive(false);
        }

        /*IEnumerator DragDrinkFinalPosition(GameObject drink)
        {
            bool isOnPlace = false;
            drink.transform.SetParent(drinkFinalPosition, true);

            RectTransform drinkTransform = drink.GetComponent<RectTransform>();

            Debug.Log($"Comecou coisinha com go {drink.name}");
            
            while (!isOnPlace)
            {
                Debug.Log("Iteracao");
                drinkTransform.localPosition = Vector2.Lerp(drinkTransform.localPosition, Vector2.zero, 5 * Time.deltaTime);

                if (drinkTransform.localPosition.x <= .1f && drinkTransform.localPosition.x >= -.1f)
                {
                    Debug.Log(drinkTransform.localPosition);
                    drinkTransform.localPosition = Vector2.zero;
                    isOnPlace = true;
                }
                yield return null;
            }
            Debug.Log("terminou");
        }*/
    }

}