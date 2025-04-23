using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

//get variabales to transfer between classes
public class KeepVariables : MonoBehaviour
{
    public static float sensY = 25;

    public static float sensX = 12.5f;

    public static float volumeFloat;

    public static bool fullScreen;
}

public static class SaveSystem {

    public static void SaveScene(Scene scene)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        Save data = new Save();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Save LoadScene () 
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream (path, FileMode.Open);

            Save data = formatter.Deserialize(stream) as Save;
            stream.Close();
            return data;
        }
        else
        { 
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    
    }


}
