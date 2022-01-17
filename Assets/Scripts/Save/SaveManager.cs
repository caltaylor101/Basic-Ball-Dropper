using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "/MyData.obb";
    public static string fileName2 = "/MyData2.obb";
    public static string fileName3 = "/MyData3.obb";
    public static string fileName4 = "/MyData4.obb";

    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }

    public static void SaveClickBall(SaveClickBall so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName2, json);
    }

    public static void SaveAutoBall(SaveClickBall so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName3, json);
    }


    public static void SavePrefabs(SavePrefabs so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName4, json);
    }



    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject so = new SaveObject();

        if(File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("Save files does not exist");
        }
        

        return so; 
    }

    public static SaveClickBall LoadClickBall()
    {
        string fullPath2 = Application.persistentDataPath + directory + fileName2;
        SaveClickBall cb = new SaveClickBall();
        if (File.Exists(fullPath2))
        {
            string json = File.ReadAllText(fullPath2);
            cb = JsonUtility.FromJson<SaveClickBall>(json);

        }
        else
        {
            Debug.Log("Save file for clickball doesn't exist");
        }
        return cb;

    }
    
    public static SaveAutoBall LoadAutoball()
    {
        string fullPath3 = Application.persistentDataPath + directory + fileName3;
        SaveAutoBall ab = new SaveAutoBall();
        if (File.Exists(fullPath3))
        {
            string json = File.ReadAllText(fullPath3);
            ab = JsonUtility.FromJson<SaveAutoBall>(json);

        }
        else
        {
            Debug.Log("Save file for autoball doesn't exist");
        }
        return ab;

    }




}
