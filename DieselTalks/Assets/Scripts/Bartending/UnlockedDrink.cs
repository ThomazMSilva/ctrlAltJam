using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnlockedDrink : MonoBehaviour, IPointerClickHandler
{
    public int index;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.recipeBook.OpenDescription(gameObject);
    }
}
