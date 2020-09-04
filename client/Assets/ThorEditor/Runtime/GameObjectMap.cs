using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MapItem
{
    public string name;
    public GameObject go;
}


public class GameObjectMap : MonoBehaviour
{

    public MapItem[] mapItems = new MapItem[] { };

    private Dictionary<string, GameObject> mapsItemsDic;

    private bool isInit = false;
   
    void Init()
    {
        if (!isInit)
        {
            mapsItemsDic = new Dictionary<string, GameObject>();
            foreach (var k in mapItems)
            {
                if (!mapsItemsDic.ContainsKey(k.name))
                    mapsItemsDic.Add(k.name, k.go);
                else
                    Debug.LogError($"duplicate name {k.name}");
            }
            isInit = true;
        }
    }

    public Object Get(string name)
    {
        if (mapsItemsDic == null)
        {
            Init();
        }
        GameObject ret;
        if (!mapsItemsDic.TryGetValue(name,out ret))
        {
            return null;
        }
        return ret;
    }

   
}

