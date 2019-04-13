using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text;
using System.IO;

public class AudioWindowEditor : EditorWindow {
    

    string audioName;
    string audioPath;
    Dictionary<string, string> audioDict = new Dictionary<string, string>();
    private void Awake()
    {
        LoadAudioList();
    }

    private void OnInspectorUpdate()
    {
        LoadAudioList();
    }

    [MenuItem("Manager/AuidoManager")]
    static void CreateWindow()
    {
        AudioWindowEditor window = EditorWindow.GetWindow<AudioWindowEditor>("音效管理");
        window.Show();
    }

    private void OnGUI()
    {
        foreach(string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);
            if (GUILayout.Button("delete"))
            {
                audioDict.Remove(key);
                SaveAudioList();
                return;
            }
            GUILayout.EndHorizontal();
        }

        audioName = EditorGUILayout.TextField("音效名字", audioName);
        audioPath =EditorGUILayout.TextField("音效路径", audioPath);
        if (GUILayout.Button("add"))
        {
            Object o = Resources.Load(audioPath);
            if (o == null)
            {
                Debug.LogWarning("添加不成功");
            }
            else
            {
                if (audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning("名字已存在");
                }
                audioDict.Add(audioName, audioPath);
                SaveAudioList();
            }
        }
    }
    void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();
        foreach(string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            sb.Append(key + ',' + value + "\n");
        }
        File.WriteAllText(AudioManager.AudioPath, sb.ToString());
    }

    void LoadAudioList()
    {
        audioDict = new Dictionary<string, string>();
        if (File.Exists(AudioManager.AudioPath) == false) return;
        string[] lines = File.ReadAllLines(AudioManager.AudioPath);
        foreach(string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyValue = line.Split(',');
            audioDict.Add(keyValue[0], keyValue[1]);
        }
    }
}
