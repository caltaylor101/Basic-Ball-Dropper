using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "MyData.txt";
    public static string fileName2 = "MyData2.txt";
    public static string fileName3 = "MyData3.txt";
    public static string fileName4 = "MyData4.txt";
    public static string fileName5 = "MyData5.txt";
    public static string fileName6 = "MyData6.txt";

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

    public static void SaveAutoBall(SaveAutoBall so)
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

        SavePrefab[] prefabList = new SavePrefab[so.prefabList.Count + 1];

        for (int i = 0; i < so.prefabList.Count; i++)
        {
            prefabList[i] = new SavePrefab();
            prefabList[i].positionX = so.prefabList[i].positionX;
            prefabList[i].positionY = so.prefabList[i].positionY;
            prefabList[i].positionZ = so.prefabList[i].positionZ;
            prefabList[i].damagePower = so.prefabList[i].damagePower;
            prefabList[i].damageMultiplier = so.prefabList[i].damageMultiplier;
        }

        string listToJson = JsonHelper.ToJson(prefabList, true);

        File.WriteAllText(dir + fileName4, listToJson);
        
    }

    public static void SaveHittableObjects(HittableObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        if (File.Exists(dir + fileName5))
        {
            string json = File.ReadAllText(dir + fileName5);
            string[] _tempNameList = JsonHelper.FromJson<string>(json);
            List<string> _editNameList = _tempNameList.OfType<string>().ToList();
            _editNameList.Add(so.name);
            string[] newArrayToSave = _editNameList.ToArray();
            string newJsonToSave = JsonHelper.ToJson<string>(newArrayToSave);
            File.WriteAllText(dir + fileName5, newJsonToSave);
        }
        else
        {
            List<string> nameList = new List<string>();
            nameList.Add(so.name);
            string[] arrayToSave = nameList.ToArray();
            string jsonToSave = JsonHelper.ToJson<string>(arrayToSave);
            File.WriteAllText(dir + fileName5, jsonToSave);
        }

    }

    public static void SaveUpgradeBallVariables(UpgradeBallVariables so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName6, json);
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

    public static SavePrefabs LoadPrefabs()
    {

        string fullPath4 = Application.persistentDataPath + directory + fileName4;
        SavePrefabs sp = new SavePrefabs();
        if (File.Exists(fullPath4))
        {
            string json = File.ReadAllText(fullPath4);
            SavePrefab[] newList = JsonHelper.FromJson<SavePrefab>(json);
            List<SavePrefab> prefabList = new List<SavePrefab>();
            
            for (int i = 0; i < newList.Length -1; i++)
            {
                SavePrefab newPrefab = new SavePrefab();
                newPrefab.positionX = newList[i].positionX;
                newPrefab.positionY = newList[i].positionY;
                newPrefab.positionZ = newList[i].positionZ;
                newPrefab.damagePower = newList[i].damagePower;
                newPrefab.damageMultiplier = newList[i].damageMultiplier;
                prefabList.Add(newPrefab);
            }

            sp.prefabList = prefabList;
        }
        else
        {
            Debug.Log("Save file for prefabs doesn't exist");
        }
        return sp;

    }

    public static HittableObjectList LoadHittableObjects()
    {
        string fullPath5 = Application.persistentDataPath + directory + fileName5;
        HittableObjectList returnObject = new HittableObjectList();
        if (File.Exists(fullPath5))
        {
            string json = File.ReadAllText(fullPath5);
            string[] newArray = JsonHelper.FromJson<string>(json);
            List<string> nameList = new List<string>();
            nameList = newArray.OfType<string>().ToList();

            returnObject.nameList = nameList;
        }
        else
        {
            Debug.Log("Save file for prefabs doesn't exist");
        }
        return returnObject;

    }

    public static UpgradeBallVariables LoadUpgradeBallVariables()
    {
        string fullPath6 = Application.persistentDataPath + directory + fileName6;
        UpgradeBallVariables ab = new UpgradeBallVariables();
        if (File.Exists(fullPath6))
        {
            string json = File.ReadAllText(fullPath6);
            ab = JsonUtility.FromJson<UpgradeBallVariables>(json);
        }
        else
        {
            Debug.Log("Save file for autoball doesn't exist");
        }
        return ab;
    }


    public static void DeleteObjectListData()
    {
        string fullPath5 = Application.persistentDataPath + directory + fileName5;
        File.Delete(fullPath5);
    }
    public static void DeleteBallListData()
    {
        string fullPath4 = Application.persistentDataPath + directory + fileName4;
        File.Delete(fullPath4);
    }



    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }


}
