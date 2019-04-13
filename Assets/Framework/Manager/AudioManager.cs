using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager {
    static string audioPathPrefix = Application.dataPath + "/Framework/Resources/";
    const string audioPathMiddle = "AudioList";
    const string audioPathPostfix = ".txt";

    public static string AudioPath
    {
        get
        {
            return audioPathPrefix + audioPathMiddle +audioPathPostfix;
        }
    }
    Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();

    //public AudioManager()
    //{
    //    LoadAudioClip();
    //}\

    public bool isMute = false;

    public void Initialize()
    {
        LoadAudioClip();
    }

    void LoadAudioClip()
    {
        audioClipDic = new Dictionary<string, AudioClip>();
        TextAsset ta = Resources.Load<TextAsset>(audioPathMiddle);
        string[] lines = ta.text.Split('\n');
        foreach(string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyValue = line.Split(',');
            string key = keyValue[0];
            AudioClip value = Resources.Load<AudioClip>( keyValue[1]);
            audioClipDic.Add(key, value);
        }
    }
    public void Play(string name)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDic.TryGetValue(name ,out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, Vector3.zero);
        }
    }
    public void Play(string name,Vector3 position)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDic.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, position);
        }
    }
}
