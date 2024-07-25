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


        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Saiu");
            rectTransform.localScale = transformScale; 
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Entrou");
            rectTransform.localScale = transformScale * 1.1f;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Clicked");
            GameObject go = Instantiate(ingredientPrefab, rectTransform);
            Debug.Log($"Instanciou {go.name}");
            go.transform.parent = parent;
        }
    }
}