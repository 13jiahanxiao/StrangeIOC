using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PoolManagerEdit {
    [MenuItem("Manager/Create Pool Config")]
    static void CreateGameObjectPoolList()
    {
        string path = "Assets/"+PoolManager.PoolConfigPath;
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();
        AssetDatabase.CreateAsset(poolList,path);
        AssetDatabase.SaveAssets();
    }
}
