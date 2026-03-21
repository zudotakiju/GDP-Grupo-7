using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static readonly string save_folder = Application.persistentDataPath + "/SaveSystem/";
    public static readonly string file_ext = ".json";

    public static void Save(string filename, string dataToSave)
    {
        if (!Directory.Exists(save_folder))
        {
            Directory.CreateDirectory(save_folder);
        }

        File.WriteAllText(save_folder + filename + file_ext, dataToSave);
    }

    public static string Load(string filename)
    {
        string fileloc = save_folder + filename + file_ext;
        if(File.Exists(save_folder + filename + file_ext))
        {
            string loadedData = File.ReadAllText(fileloc);
            return loadedData;
        }
        else
        {
            return null;
        }
    }
}
