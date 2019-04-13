using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameObjectPool {
    [SerializeField]
    public string name;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    int maxAmount = 0;

    [NonSerialized]
    List<GameObject> prefabList = new List<GameObject>();

    public GameObject GetInstance()
    {
        foreach(GameObject go in prefabList)
        {
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
                return go;
            }
        }
        if (prefabList.Count >= maxAmount)
        {
            GameObject.Destroy(prefabList[0]);
            prefabList.RemoveAt(0);
        }

        GameObject temp = GameObject.Instantiate<GameObject>(prefab);
        prefabList.Add(temp);
        return temp;
    }
}
