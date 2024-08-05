using Assets.Scripts;
using Assets.Scripts.Bartending;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;
    public static GameManager Instance
    {
        get
        {
            if (!_Instance)
            {
                Debug.Log("Criou gms");
                var prefab = Resources.Load<GameObject>("Prefabs/-_GameManager_-");

                var inScene = Instantiate(prefab);

                _Instance = inScene.GetComponentInChildren<GameManager>();
                if (!_Instance) _Instance = inScene.AddComponent<GameManager>();
                DontDestroyOnLoad(_Instance.transform.root.gameObject);
            }
            return _Instance;
        }
    }

    [Space(8f), Header("Administradores"), Space(5f)]
    public LevelManager LevelManager;
    public DataManager DataManager;
    public CharacterManager CharacterManager;
    public AudioManager AudioManager;
    public RecipeBook recipeBook;

    private void Awake()
    {
        LevelManager.OnLevelUp += Fade;

        originalColor = transitionScreen.color;
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NewGame();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }*/


    [Space(8f)/*, Header("Menu Configurações"), Space(5f)*/]

    [SerializeField] GameObject pauseScreen, creditsScreen;

    public void SwitchOptionsScreen() => pauseScreen.SetActive(!pauseScreen.activeSelf);
    public void SwitchCreditsScreen() => creditsScreen.SetActive(!creditsScreen.activeSelf);
    public void SwitchRecipeBook() => recipeBook.recipeScreen.SetActive(!recipeBook.recipeScreen.activeSelf);

    [Space(8f), Header("Transição em Fade"), Space(5f)]
    [SerializeField] UnityEngine.UI.Image transitionScreen;
    [SerializeField]Color originalColor;
    [SerializeField, Range(.1f, 5)] float transitionTime;
    [SerializeField] float transitionHold = .5f;

    public delegate void MidFade();
    public event MidFade OnMidFade;

    public void NewGame()
    {
        LoadScene(1);
        DataManager.NewGame();
        Debug.Log("GameManager New Game");
    }

    public void SaveGame()
    {
        DataManager.SaveGame();
        Debug.Log("GameManager Save Game");
    }

    public void LoadGame()
    {
        LoadScene(1);
        DataManager.LoadGame();
        Debug.Log("GameManager Load Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScene(int sceneIndex)
    {
        StopAllCoroutines();
        StartCoroutine(LoadSceneAsynchronously(sceneIndex));
    }

    public void Fade()
    {
        StopAllCoroutines();
        StartCoroutine(FadeTransition(transitionTime));
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
            AudioManager.SwitchMusic();
            loadingBackground.SetActive(false);
        }
    }

}
