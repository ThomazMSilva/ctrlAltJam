using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Bartending
{
    public class Ingredient : MonoBehaviour, IPointerClickHandler
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
            canvas = FindObjectOfType<CanvasReference>().canvas;
            mainCamera = Camera.main;
            //Debug.Log("Spawnou");
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
                //Debug.Log("n foi 1!");
                return;
            }

            if (colidido == colisorCirculoAtual)
            {
                //Debug.Log("n foi 2!");
                return;
            }
            //Debug.Log("Colidiu com Magic Circle");
            circuloColidido = colidido.GetComponent<DrinkMix>();
            colisorCirculoColidido = colidido;


        }
        private void OnTriggerExit2D(Collider2D colidido)
        {
            if (colidido == colisorCirculoColidido)
            {
                circuloColidido = null;
                colisorCirculoColidido = null;
                //Debug.Log("Saiu do Magic Circle");
            }
        }


        private void OnMouseReleased()
        {
            if (!isDragged)
            {
                //Debug.Log("is not dragged");
                return;
            }

            StopAllCoroutines();

            isDragged = false;
            isCoroutineRunning = false;

            if (circuloColidido != null)
            {
                //Debug.Log("Circul colidido: "+circuloColidido.name);
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

            //Debug.Log($"Camera: {mainCamera.name}; canvas: {canvas.name}; rectTransform: {rectTransform}");

            float tempoAtual = 0;

            while (tempoAtual < holdTime && isDragged) { tempoAtual += Time.deltaTime; yield return null; }
            
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();

            while (isDragged)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle
                (
                    canvasRect, 
                    Input.mousePosition, 
                    mainCamera, 
                    out pointerScreenPointToCanvas
                );

                rectTransform.anchoredPosition = pointerScreenPointToCanvas;
                yield return null;

                /*Debug.Log
                (
                    $"canvasrect: {canvasRect};" +
                    $" mousepos: {Input.mousePosition};" +
                    $" camera: {mainCamera};" +
                    $" rendermode: {canvas.renderMode}" +
                    $" out: {pointerScreenPointToCanvas}"
                );



                Vector3 followPosition = canvas.transform.TransformPoint(pointerScreenPointToCanvas);

                Debug.Log($"pointerScreenPointToCanvas: {pointerScreenPointToCanvas}");
                Debug.Log($"followPosition: {followPosition}");
                Debug.Log($"rectTransform.position: {rectTransform.position}");
                Debug.Log($"rectTransform.anchoredPosition: {rectTransform.anchoredPosition}");

                rectTransform.anchoredPosition = followPosition;*/
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

        public void OnPointerClick(PointerEventData eventData)
        {
            if(circuloAtual == null) return;
            circuloAtual.EmptyCircle(this);
        }
    }

}