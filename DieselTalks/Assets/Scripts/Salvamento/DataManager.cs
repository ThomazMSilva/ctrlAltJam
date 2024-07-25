using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    [SerializeField] string fileName = "dados-salvos.json";
    private FileHandler fileHandler;
    private SavedData gameData;
    private List<ISavable> dataHandlers;


    private void Awake()
    {
        gameData = new SavedData();
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
        foreach (ISavable handler in dataHandlers) { handler.SaveData(ref gameData); }
        
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
        foreach (ISavable handler in dataHandlers) { handler.LoadData(gameData); }

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    List<ISavable> FindAllDataHandlers()
    {
        IEnumerable<ISavable> dataHandlers = FindObjectsOfType<MonoBehaviour>().OfType<ISavable>();
        return new List<ISavable>(dataHandlers);
    }
}
