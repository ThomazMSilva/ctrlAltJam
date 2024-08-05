using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject
            pauseScreen,
            brewingScreen;

        //[SerializeField] ImageFade brewingBackground;

        //[SerializeField] private GameObject recipeScreen;
        private bool
            isPaused = false,
            isBrewing = false;
        //private bool isOpened;

        public void SwitchRecipeBook()
        {
            GameManager.Instance.SwitchRecipeBook();
        }

        public void SaveGame() 
        {
            GameManager.Instance.SaveGame();       
        }

        public void SwitchOptions()
        {
            GameManager.Instance.SwitchOptionsScreen();
        }

        public void LoadMenu()
        {
            GameManager.Instance.LoadScene(0);
        }

        public void SwitchBrewingScreen()
        {

            isBrewing = !isBrewing;
            brewingScreen.SetActive(isBrewing);
            /*brewingBackground.SwitchState();
            StopAllCoroutines();
            StartCoroutine(DragBrewingScreen(!isBrewing));*/

        }

        IEnumerator DragBrewingScreen(bool hasOpened)
        {
            RectTransform rectTransform = brewingScreen.GetComponent<RectTransform>();

            Vector2 target = new(hasOpened ? 1161 : 0, 0);

            while ( hasOpened != isBrewing)
            {
                rectTransform.localPosition = Vector2.Lerp(rectTransform.localPosition, target, 10 * Time.deltaTime);

                if (rectTransform.localPosition.x <= target.x + .1f &&
                    rectTransform.localPosition.x >= target.x - .1f)
                {
                    rectTransform.localPosition = target;
                    hasOpened = isBrewing;
                }

                yield return null;
            }
        }

        public void SwitchPauseScreen()
        {
            isPaused = !isPaused;
            pauseScreen.SetActive(isPaused);
        }

/*
         IEnumerator MovePorta(bool vaiAbrir)
    {
        Quaternion rotacaoAlvo = Quaternion.Euler(new(porta.rotation.x, estaPortaAberta ? 0 : abertura, porta.rotation.z));

        int indiceSom = Random.Range(0, sonsPortaAbrindo.Length - 1);
        
        if (!estaPortaAberta)
        {
            audioSource.clip = sonsPortaAbrindo[indiceSom];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = sonsPortaFechando[indiceSom];
            audioSource.Play();
        }

        while (vaiAbrir != estaPortaAberta)
        {
            porta.localRotation = Quaternion.Lerp(porta.localRotation, rotacaoAlvo, Time.deltaTime);

            if (porta.localRotation.y <= rotacaoAlvo.y + .1f && porta.localRotation.y >= rotacaoAlvo.y - .1f) estaPortaAberta = vaiAbrir;
            
            yield return null;
        }

        yield return null;
    }
*/
    }
}