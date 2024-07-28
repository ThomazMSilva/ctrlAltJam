using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Dialogue_related
{
    public class OrderManager : MonoBehaviour
    {
        public List<OrderDialogue> orderList;

        public OrderDialogue currentOrderDialogue;

        // Use this for initialization
        private void Start()
        {
            var list = FindObjectsOfType<OrderDialogue>(true);
            orderList = list.OrderBy
                            (o => o.orderIndex).ThenBy
                                                (o => o.orderingCharacter).ToList();

            UpdateCurrentOrderDialogue();

            currentOrderDialogue.gameObject.SetActive(true);

            GameManager.Instance.LevelManager.OnLevelUp += UpdateCurrentOrderDialogue;

            GameManager.Instance.OnMidFade += ActivateCurrentDialogue;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnMidFade -= ActivateCurrentDialogue;
        }

        public void ActivateCurrentDialogue() => currentOrderDialogue.gameObject.SetActive(true);

        public void DeactivateCurrentDialogue() => currentOrderDialogue.FinishDialogue(true);

        void UpdateCurrentOrderDialogue()
        {
            if (currentOrderDialogue != null) currentOrderDialogue?.gameObject.SetActive(false);

            currentOrderDialogue = currentOrderDialogue = orderList[GameManager.Instance.LevelManager.level];

            //currentOrderDialogue.gameObject.SetActive(true);
        }
        
    }
}