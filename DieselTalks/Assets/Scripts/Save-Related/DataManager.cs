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
        gameData ??= new SavedData();
    }

    private void Start()
    {
        fileHandler = new FileHandler(Application.persistentDataPath, fileName);
        //dataHandlers = FindAllDataHandlers();
    }

    public void NewGame()
    {
        dataHandlers = FindAllDataHandlers();
        gameData = new SavedData();
        foreach (ISavable handler in dataHandlers) { handler.LoadData(gameData); }
    }
    public void SaveGame()
    {
        foreach (ISavable handler in dataHandlers) { handler.SaveData(ref gameData); }
        
        fileHandler.Save(gameData);
    }
    public void LoadGame()
    {
        dataHandlers = FindAllDataHandlers();
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

        string str = "";
        foreach (ISavable handler in dataHandlers) str += handler.ToString();
        //Debug.Log($"FindAllDataHandlers in DataManager {gameObject.name}:\n {str}");

        return new List<ISavable>(dataHandlers);
    }
}
