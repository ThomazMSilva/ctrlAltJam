using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class IngredientSpawner : MonoBehaviour
    {
        RectTransform rectTransform;
        Vector3 transformScale;
        [SerializeField] GameObject ingredientPrefab;
        [SerializeField] Transform parent;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            transformScale = rectTransform.localScale;
        }

        public void OnMouseEnter()
        {
                rectTransform.localScale = transformScale * 1.1f;
        }
        public void OnMouseExit()
        {
                rectTransform.localScale = transformScale;
        }

        private void OnMouseDown()
        {
            GameObject go = Instantiate(ingredientPrefab, rectTransform);
            go.transform.parent = parent;

        }
    }
}