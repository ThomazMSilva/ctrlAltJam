using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class Ingredient : MonoBehaviour
    {
        public Texture ingredientTexture;
        public Taste ingredientTaste;

        public bool isBase;

        [Space(8f), Header("Serializados Essenciais"), Space(4f)]

        [SerializeField] RectTransform rectTransform;

        [SerializeField] Camera mainCamera;

        [SerializeField] Canvas canvas;

        [HideInInspector]
        public Vector2
            currentPos,
            pointerScreenPointToCanvas;

        [Space(8f), Header("Variaveis de Tempo"), Space(4f), SerializeField]

        private float holdTime = .1f;
        //private float tempoAtual = 0;

        [HideInInspector]
        public bool
            canDrag = true,
            isDragged = false,
            isCoroutineRunning;

        DrinkMix
            circuloColidido,
            circuloAtual;
        Collider2D
            colisorCirculoColidido,
            colisorCirculoAtual;



        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            canvas = FindObjectOfType<Canvas>();
            mainCamera = Camera.main;

            StartCoroutine(FollowCursor());
        }

        private void Update()
        {
            if (isDragged && Input.GetMouseButtonUp(0))
            {
                OnMouseReleased();
            }
        }

        private void OnTriggerEnter2D(Collider2D colidido)
        {
            if (!colidido.CompareTag("Magic Circle"))
            {
                Debug.Log("n foi 1!");
                return;
            }

            if (colidido == colisorCirculoAtual)
            {
                Debug.Log("n foi 2!");
                return;
            }
                

            Debug.Log("Iupii!");

            circuloColidido = colidido.GetComponent<DrinkMix>();
            colisorCirculoColidido = colidido;


        }
        private void OnTriggerExit2D(Collider2D colidido)
        {
            if (colidido == colisorCirculoColidido)
            {
                circuloColidido = null;
                colisorCirculoColidido = null;
            }
        }


        private void OnMouseReleased()
        {
            if (!isDragged)
            {
                Debug.Log("is not dragged");
                return;
            }

            StopAllCoroutines();

            isDragged = false;
            isCoroutineRunning = false;

            if (circuloColidido != null)
            {
                Debug.Log("Circul colidido: "+circuloColidido.name);
                circuloAtual = circuloColidido;
                colisorCirculoAtual = colisorCirculoColidido;

                circuloColidido = null;
                colisorCirculoColidido = null;

                circuloAtual.SetIngredient(this, rectTransform);
            }

           /* else if (circuloAtual != null && circuloAtual.CurrentTexture == null)
                circuloAtual.ChangeIngredient(this);*/


            if (circuloAtual != null) return;

            Destroy(gameObject);

        }

        private IEnumerator FollowCursor()
        {
            isCoroutineRunning = true;
            isDragged = true;

            //rectTransform.SetAsLastSibling();
            float tempoAtual = 0;

            while (tempoAtual < holdTime && isDragged) { tempoAtual += Time.deltaTime; yield return null; }

            while (isDragged)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, mainCamera, out pointerScreenPointToCanvas);

                //rectTransform.anchoredPosition = pointerScreenPointToCanvas;

                Vector3 posicaoSeguir = canvas.transform.TransformPoint(pointerScreenPointToCanvas); ;
                transform.position = posicaoSeguir; ;

                yield return null;
            }
        }

        public void AddIngredient(DrinkMix drink)
        {
            if (isBase) drink.drinkTexture = ingredientTexture;
            else drink.drinkTaste = ingredientTaste;
        }

        public void AddIngredient()
        {
            if (isBase)
            {
                Debug.Log($"Adicionando textura {ingredientTexture} ao drink :3");
                DrinkManager.SetCurrentDrinkTexture(ingredientTexture);
            }
            else
            {
                Debug.Log($"Adicionando gosto {ingredientTaste} ao drink Ò-Ó");
                DrinkManager.SetCurrentDrinkTaste(ingredientTaste);
            }
        }
    }

}