using UnityEngine;
using UnityEngine.EventSystems;

public class TextMeshProClickHandler : MonoBehaviour, IPointerClickHandler
{
    public delegate void ClickAction();
    public static event ClickAction OnTextClickedEvent;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnTextClickedEvent?.Invoke();
    }
}
