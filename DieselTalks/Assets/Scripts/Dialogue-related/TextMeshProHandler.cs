using UnityEngine;
using UnityEngine.EventSystems;

public class TextMeshProHandler : MonoBehaviour, IPointerClickHandler
{
    public delegate void ClickAction();
    public static event ClickAction OnTextClickedEvent;

    /*public UnityEngine.UI.Image characterIMG;
    public ImageFade imageFade;*/

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnTextClickedEvent?.Invoke();
    }
/*
    private void OnEnable()
    {
        characterIMG.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        imageFade.DisableImage();
    }*/
}
