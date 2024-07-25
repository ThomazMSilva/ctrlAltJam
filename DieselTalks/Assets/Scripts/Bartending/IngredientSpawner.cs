using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Bartending
{
    public class IngredientSpawner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
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


        public void OnPointerExit(PointerEventData eventData) => rectTransform.localScale = transformScale;

        public void OnPointerEnter(PointerEventData eventData) => rectTransform.localScale = transformScale * 1.1f;

        public void OnPointerDown(PointerEventData eventData)
        {
            parent.gameObject.SetActive(false);
            Instantiate(ingredientPrefab, parent);
            parent.gameObject.SetActive(true);
        }
    }
}