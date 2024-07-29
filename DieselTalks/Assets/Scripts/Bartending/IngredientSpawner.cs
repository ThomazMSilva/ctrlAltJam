﻿using System.Collections;
using TMPro;
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
        [TextArea, SerializeField] string ingredientDescription = "a";
        [SerializeField] TextMeshProUGUI textMeshProUGUI;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            transformScale = rectTransform.localScale;
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log($"Saiu de {gameObject.name}");
            rectTransform.localScale = transformScale;
            textMeshProUGUI.text = "";
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log($"Entrou de {gameObject.name}");
            rectTransform.localScale = transformScale * 1.1f;
            textMeshProUGUI.text = ingredientDescription;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            GameManager.Instance.AudioManager.PlayPoppingSound();
            parent.gameObject.SetActive(false);
            Instantiate(ingredientPrefab, parent);
            parent.gameObject.SetActive(true);
        }
    }
}