using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; }

    [SerializeField] string fileName;
    private FileHandler fileHandler;
    private SavedData gameData;
    private List<IDataHandler> dataHandlers;


    private void Awake()
    {
        if (instance != null) Debug.LogError("Nao deveria haver uma instancia do DataHandler, por ser um singleton – Mas há.");
        instance = this;
        gameData = new SavedData();
        DontDestroyOnLoad(instance.gameObject);

    }
    private void Start()
    {
        fileHandler = new FileHandler(Application.persistentDataPath, fileName);
        dataHandlers = FindAllDataHandlers();
    }

    public void NewGame()
    {
        this.gameData = new SavedData();
    }
    public void SaveGame()
    {
        foreach (IDataHandler handler in dataHandlers) { handler.SaveData(ref gameData); }
        
        fileHandler.Save(gameData);
    }
    public void LoadGame()
    {
        this.gameData = fileHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("Nao tem save ow estranho. Vai de novojogo memo>");
            NewGame();
        }
        foreach (IDataHandler handler in dataHandlers) { handler.LoadData(gameData); }

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    List<IDataHandler> FindAllDataHandlers()
    {
        IEnumerable<IDataHandler> dataHandlers = FindObjectsOfType<MonoBehaviour>().OfType<IDataHandler>();
        return new List<IDataHandler>(dataHandlers);
    }
}
