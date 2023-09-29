using System;
using System.IO;
using UnityEngine;

public class DataManager
{
    /* Json ������ ������ �ε��ϱ� ���� �޼���
     */
    T LoadJsonData<T>(string path, bool isInternal)
    {
        if (isInternal)
            path = $"{Application.dataPath}/{path}";
        string loadedText;
        try
        {
            loadedText = File.ReadAllText(path);
            T loadedData = JsonUtility.FromJson<T>(loadedText);
            Debug.Log("Fild loaded successfully!");
            return loadedData;
        }
        catch (Exception e)
        {
            Debug.LogError($"File load failed! {e.Message}");
            return default(T);
        }
    }
}
