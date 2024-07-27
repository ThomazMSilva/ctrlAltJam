using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class ButtonOnPointerEnter : MonoBehaviour, IPointerEnterHandler
    {
        AudioManager mng;

        private void Start()
        {
            mng = GameManager.Instance.AudioManager;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            mng.PlayButtonEnterSound();
        }
    }
}