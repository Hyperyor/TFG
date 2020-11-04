﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSaver : MonoBehaviour
{
    public static void SaveObject(object obj)
    {
        StreamWriter file = File.CreateText(GetPath(obj.GetType()));
        file.Write(JsonUtility.ToJson(obj));
        file.Dispose();
    }

    public static T GetFile<T>()
    {
        string jsonSerialized = File.ReadAllText(GetPath(typeof(T)));
        return JsonUtility.FromJson<T>(jsonSerialized);
    }

    private static string GetPath(System.Type type)
    {
        string path = Application.persistentDataPath;
        Debug.Log(Application.persistentDataPath);
        path += "\\" + type.ToString() + ".txt";
        return path;
    }
}