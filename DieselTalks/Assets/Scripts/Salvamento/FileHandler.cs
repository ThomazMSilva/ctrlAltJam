using UnityEditor;
using UnityEngine;
using System.IO;

public class FileHandler
{
    private string
        filePath = "",
        fileName = "";

    

    public FileHandler(string filePath, string fileName)
    {
        this.filePath = filePath;
        this.fileName = fileName;
    }   

    public SavedData Load()
    {
        string path = Path.Combine(filePath, fileName);
        SavedData loadedGameData = null;
        if (File.Exists(path))
        {
            try
            {
                string dataToLoad = "";
                using(FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream)) 
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedGameData = JsonUtility.FromJson<SavedData>(dataToLoad);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Nao conseguiu carregar: {e}");
            }
        }
        return loadedGameData;
    }
    public void Save(SavedData data)
    {
        string path = Path.Combine(filePath, fileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(path, FileMode.Create)) 
            {
                using (StreamWriter writer = new StreamWriter(stream)) 
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Deu erro salvando arquivo. {path} \n {e}");
            throw;
        }
    }

}
