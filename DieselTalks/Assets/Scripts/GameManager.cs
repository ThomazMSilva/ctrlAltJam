using Assets.Scripts;
using Assets.Scripts.Bartending;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Space(8f), Header("Administradores"), Space(5f)]
    public LevelManager LevelManager;
    public DataManager DataManager;
    public CharacterManager CharacterManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogError("Ja existe uma instancia de LevelManager e ta tentando instanciar uma no Awake");
            Destroy(gameObject);
        }
        LevelManager.OnLevelUp += Fade;

        originalColor = transitionScreen.color;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Fade();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            LoadScene(1);
        }
    }

    [Space(8f), Header("Transição em Fade"), Space(5f)]
    [SerializeField] UnityEngine.UI.Image transitionScreen;
    [SerializeField]Color originalColor;
    [SerializeField, Range(.1f, 5)] float transitionTime;
    [SerializeField] float transitionHold = .5f;

    public delegate void MidFade();
    public event MidFade OnMidFade;

    public void Fade()
    {
        StopAllCoroutines();
        StartCoroutine(FadeTransition(transitionTime));
    }

    public void LoadScene(int sceneIndex)
    {
        StopAllCoroutines();
        StartCoroutine(LoadSceneAsynchronously(sceneIndex));
    }

    IEnumerator FadeTransition(float tempoTransicaoGeral)
    {
        //Debug.Log("Ta dando fade");
        float
            tempoTransicaoDividido = tempoTransicaoGeral * .5f,
            multiplicadorTempo = 1 / tempoTransicaoDividido;

        
        
        Color currentColor = originalColor; currentColor.a = 0;
        transitionScreen.color = currentColor;

        transitionScreen.gameObject.SetActive(true);
        //Debug.Log($"TransitionScreen Starting Color: {transitionScreen.color}; Starting Alpha: {transitionScreen.color.a}");

        while (transitionScreen.color.a < originalColor.a)
        {
            //Debug.Log($"Fading In - TransitionScreen Color: {transitionScreen.color}; Alpha: {transitionScreen.color.a}");
            currentColor.a += originalColor.a * (Time.deltaTime * multiplicadorTempo);
            transitionScreen.color = currentColor;
        
            yield return null;
        }

        //Faz algo aqui no meio s quise
        //yield return StartCoroutine(LoadScene(1));
        OnMidFade?.Invoke();
        yield return new WaitForSeconds(transitionHold);

        while (transitionScreen.color.a > 0)
        {
            //Debug.Log($"Fading Out - TransitionScreen Color: {transitionScreen.color}; Alpha: {transitionScreen.color.a}");
            currentColor.a -= originalColor.a * (Time.deltaTime * multiplicadorTempo);
            transitionScreen.color = currentColor;
            
            yield return null;
        }
        //Debug.Log("Ended");
        transitionScreen.gameObject.SetActive(false);
        yield return null;
    }

    [Space(8f), Header("Tela de Carregamento"), Space(5f)]
    [SerializeField] GameObject loadingBackground;
    [SerializeField] UnityEngine.UI.Image loadingBar;
    IEnumerator LoadSceneAsynchronously(int scene)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scene);

        if (loadingBackground != null)
        {
            loadingBackground.SetActive(true);
            while (!sceneLoading.isDone)
            {
                loadingBar.fillAmount = sceneLoading.progress;
                yield return null;
            }
            loadingBackground.SetActive(false);
        }
    }

}
