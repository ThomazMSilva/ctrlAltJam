using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Dialogue_related
{
    public class OrderDialogue : DialogueBehaviour
    {
        public CharacterKey orderingCharacter;
        [Range(0,2),Tooltip("0 = Primeiro pedido da pessoa, 1 = Segundo pedido, etc;")]
        public int orderIndex;
    }
}