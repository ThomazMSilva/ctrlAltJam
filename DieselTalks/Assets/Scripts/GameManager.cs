using Assets.Scripts;
using Assets.Scripts.Bartending;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public LevelManager LevelManager;
    public DataManager DataManager;
    public CharacterManager CharacterManager;
    public DrinkManager DrinkManager;

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
    }
}
