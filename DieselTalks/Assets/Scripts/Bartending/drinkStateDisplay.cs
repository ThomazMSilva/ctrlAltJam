using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class DrinkStateDisplay : MonoBehaviour
    {
        //public RecipeBook book;
        public TextMeshProUGUI textMeshPro;

        private RecipeBook book;

        private void Start()
        {
            book = GameManager.Instance.recipeBook;
        }

        // Update is called once per frame
        void Update()
        {
            textMeshPro.text = book.DrinkStateString();
        }
    }
}