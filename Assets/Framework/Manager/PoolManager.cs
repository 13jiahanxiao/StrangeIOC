using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager {
    private static PoolManager _Instance;
    public static PoolManager Instance
    {
        get
        {
            if (_Instance == null) _Instance = new PoolManager();
            return _Instance;
        }
    }

    static string poolConfigPathPrefix = Application.dataPath + "/Framework/Edit/Resources/";
    const string poolConfigPathMiddle = "gameobjectPool";
    const string poolConfigPathPostfix = ".asset";
    public static string PoolConfigPath
    {
        get { return poolConfigPathPrefix + poolConfigPathMiddle + poolConfigPathPostfix; }
    }

    Dictionary<string, GameObjectPool> poolDict;

    private PoolManager()
    {
        GameObjectPoolList poolList = Resources.Load<GameObjectPoolList>(poolConfigPathMiddle);
        poolDict = new Dictionary<string, GameObjectPool>();
        foreach(GameObjectPool pool in poolList.poolList)
        {
            poolDict.Add(pool.name, pool);
        }
    }

    public void Init()
    {
        //初始化调用static利用构造函数创建实例
    }

    public GameObject GetPoolInstance(string poolName)
    {
        GameObjectPool pool;
        if(poolDict.TryGetValue(poolName,out pool))
        {
            return pool.GetInstance();
        }
        Debug.LogWarning("poolName not exist");
        return null;
    }
}
