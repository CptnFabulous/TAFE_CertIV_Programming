using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Save
{
    public static void SaveData (PlayerManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter(); // create new binary formatter
        //string path = Application.persistentDataPath + "/" + player.name + ".txt"; // save path
        string path = Application.persistentDataPath + "BobDoSomething.txt"; // save path
        FileStream stream = new FileStream(path, FileMode.Create); // file stream
        Data data = new Data(player); // data
        formatter.Serialize(stream, data); // convert to binary and save to path
        stream.Close(); // end
        //print("Saved " + stream);
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "BobDoSomething.txt"; // have a path

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter(); // create new binary formatter
            FileStream stream = new FileStream(path, FileMode.Open); // file stream
            Data data = formatter.Deserialize(stream) as Data; // convert to binary and save to path
            stream.Close(); // end
            return data; // return
        }
        else
        {
            Debug.Log("Error");
            return null;
        }
    }
}
