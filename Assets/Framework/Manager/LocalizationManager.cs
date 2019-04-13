using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager {
    private static LocalizationManager _Instance;
    public static LocalizationManager Instance
    {
        get
        {
            if (_Instance == null) _Instance = new LocalizationManager();
            return _Instance;
        }
    }
    private const string Chinese = "Local/Chinese";
    private const string English = "Local/English";

    public const string language =English;

    private Dictionary<string, string> dict ;
    public LocalizationManager()
    {
        dict = new Dictionary<string, string>();
        TextAsset ta= Resources.Load<TextAsset>(language);
        string[] lines = ta.text.Split('\n');
        foreach(string line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                string[] keyValues = line.Split('=');
                dict.Add(keyValues[0], keyValues[1]);
            }
        }
    }
    public void Init()
    {

    }
    public string GetValue(string key)
    {
        string value;
        dict.TryGetValue(key, out value);
        return value;
    }
}
