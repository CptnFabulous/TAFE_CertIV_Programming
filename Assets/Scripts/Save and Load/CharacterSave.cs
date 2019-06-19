using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class CharacterSave
{
    public static void SaveData(CustomisationSet player)
    {
        BinaryFormatter formatter = new BinaryFormatter(); // create new binary formatter
        //string path = Application.persistentDataPath + "/" + player.name + ".txt"; // save path
        string path = Application.persistentDataPath + "CharacterSaveData.txt"; // save path
        FileStream stream = new FileStream(path, FileMode.Create); // file stream
        CharacterData data = new CharacterData(player); // data
        formatter.Serialize(stream, data); // convert to binary and save to path
        stream.Close(); // end
        //print("Saved " + stream);
    }

    public static CharacterData LoadData()
    {
        string path = Application.persistentDataPath + "CharacterSaveData.txt"; // have a path

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter(); // create new binary formatter
            FileStream stream = new FileStream(path, FileMode.Open); // file stream
            CharacterData data = formatter.Deserialize(stream) as CharacterData; // convert to binary and save to path
            stream.Close(); // end
            return data; // return
        }
        else
        {
            Debug.Log("Error, save file not found in " + path);
            return null;
        }
    }
}
