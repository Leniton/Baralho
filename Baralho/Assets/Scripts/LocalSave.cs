using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LocalSave : MonoBehaviour
{
    public static void Save(localData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "\\Configs"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "\\Configs");
        }
        string caminho = Application.persistentDataPath + "\\Configs\\Config.cfg";
        print(caminho);
        FileStream file = new FileStream(caminho, FileMode.Create);
        formatter.Serialize(file, data);
        file.Close();
    }

    public static localData Load()
    {
        string caminho = Application.persistentDataPath + "\\Configs\\Config.cfg";
        if (File.Exists(caminho))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(caminho, FileMode.Open);

            localData data = formatter.Deserialize(file) as localData;
            file.Close();

            return data;
        }
        else
        {
            Debug.LogError("não encontrado");
            return null;
        }
    }
}
