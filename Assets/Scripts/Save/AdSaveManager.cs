using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class AdSaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "MyData101.obb";
    public static string fileName2 = "MyData102.obb";

    // save two x reward
    public static void SaveTwoXReward(SaveTwoXObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveTwoXObject LoadRewards()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveTwoXObject so = new SaveTwoXObject();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveTwoXObject>(json);
        }
        else
        {
            Debug.Log("Save files does not exist");
        }


        return so;
    }
    //save idle time for rewards
    public static void SaveIdleReward(SaveIdleRewards so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName2, json);
    }

    public static SaveIdleRewards LoadIdleRewards()
    {
        string fullPath = Application.persistentDataPath + directory + fileName2;
        SaveIdleRewards so = new SaveIdleRewards();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveIdleRewards>(json);
        }
        else
        {
            Debug.Log("Save files does not exist");
        }


        return so;
    }

    public static void DeleteIdleRewardData()
    {
        string fullPath4 = Application.persistentDataPath + directory + fileName2;
        File.Delete(fullPath4);
    }
}
