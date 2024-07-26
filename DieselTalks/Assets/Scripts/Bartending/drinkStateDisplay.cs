using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class drinkStateDisplay : MonoBehaviour
    {
        //public RecipeBook book;
        public TextMeshProUGUI textMeshPro;
        
        // Update is called once per frame
        void Update()
        {
            textMeshPro.text = GameManager.Instance.recipeBook.DrinkStateString();
        }
    }
}