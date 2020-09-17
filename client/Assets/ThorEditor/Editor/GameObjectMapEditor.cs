using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System.IO;
using System;
using Object = UnityEngine.Object;
using UnityEngine.EventSystems;

// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and Prefab overrides.
[CustomEditor(typeof(GameObjectMap))]
[CanEditMultipleObjects]
public class GameObjectMapEditor : Editor
{
   

    public override void OnInspectorGUI()
    {
        GameObjectMap map = target as GameObjectMap;
        var p = map.GetComponentsInParent<GameObjectMap>(true);
        if (p.Length > 1)
        {
            GUILayout.Label("Sub GameObjectMap");
        }
        else
        {
            if (GUILayout.Button("Export"))
            {

                Export();
            }
        }
        base.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
    }

    public string exportPath => Application.dataPath + "/LuaScripts/src/UI/Bindings/";

    void Collect(GameObjectMap map, List<UIBehaviour> uis)
    {
        var temp = new List<UIBehaviour>();
        var buttons = map.gameObject.GetComponentsInChildren<Button>(true);
        var images = map.gameObject.GetComponentsInChildren<Image>(true);
        var texts = map.gameObject.GetComponentsInChildren<Text>(true);
        var rawImages = map.gameObject.GetComponentsInChildren<RawImage>(true);
        var toggles = map.gameObject.GetComponentsInChildren<Toggle>(true);
        var sliders = map.gameObject.GetComponentsInChildren<Slider>(true);
        var scrollbars = map.gameObject.GetComponentsInChildren<Scrollbar>(true);
        var dropdowns = map.gameObject.GetComponentsInChildren<Dropdown>(true);
        var inputFields = map.gameObject.GetComponentsInChildren<InputField>(true);

        temp.AddRange(buttons);
        temp.AddRange(images);
        temp.AddRange(texts);
        temp.AddRange(rawImages);
        temp.AddRange(toggles);
        temp.AddRange(scrollbars);
        temp.AddRange(dropdowns);
        temp.AddRange(inputFields);
        temp.AddRange(sliders);

        temp.ForEach(r =>
        {
            var p = r.GetComponentsInParent<GameObjectMap>(true);
            if (p.Length == 1) //只添加一层导出
            {
                uis.Add(r);
            }
            else
            {
                if (p[0] == map) //如果多层，第一层父节点==导出本身
                {
                    uis.Add(r);
                }
            }
        });

    }

    public void Export()
    {
        
        if (!System.IO.Directory.Exists(exportPath))
        {
            System.IO.Directory.CreateDirectory(exportPath);
        }
        if (target)
        {
            GameObjectMap map = target as GameObjectMap;
            var submaps = map.gameObject.GetComponentsInChildren<GameObjectMap>(true);


           var uis = new List<UIBehaviour>();

            Collect(map, uis);

            using (StreamWriter sw = new StreamWriter(exportPath + target.name + ".lua"))
            {
                sw.WriteLine("local ret = function(t)");

               
                Serialize(uis, sw, map);

                foreach (var k in submaps)
                {
                    if (k != map)
                    {
                        uis = new List<UIBehaviour>();
                        Collect(k, uis);
                        Serialize(uis, sw, k);
                    }
                }

                sw.WriteLine("end");
                sw.WriteLine("return ret");
            }
                
            AssetDatabase.Refresh();
        }
    }

    private string template => "\t\t table.{0} = map:Get('{0}'):GetComponent(typeof(CS.UnityEngine.UI.{1}))";


    string GetFullSubPath(GameObjectMap map)
    {
        var p = map.transform;
        string ret = p.name;

        GameObjectMap root = target as GameObjectMap;

        while (p.parent)
        {
            if (p.GetComponent<GameObjectMap>() == root)
                break;
            ret = p.parent.name + "/" + ret;
            p = p.parent;
        }
        if (ret.Contains("/"))
            ret = ret.Substring(ret.IndexOf("/") + 1);
        else
            ret = string.Empty;
        return ret;
    }

    void Serialize(List<UIBehaviour> uis, StreamWriter sw, GameObjectMap map)
    {
        Dictionary<string, int> counter = new Dictionary<string, int>();
        Dictionary<UIBehaviour, string> nameRemap = new Dictionary<UIBehaviour, string>();
        for (int i = 0; i < uis.Count; i++)
        {
            int count;
            var ui = uis[i];
            var type = uis[i].GetType().Name;
            var key = type + "_" + ui.name;
            if (counter.TryGetValue(key, out count))
            {
                counter[key] = ++count;
                if (!nameRemap.ContainsKey(ui))
                    nameRemap.Add(ui, key + "" + count);
                else
                    Debug.LogError(ui);
            }
            else
            {
                counter.Add(key, 0);
                nameRemap.Add(ui, key);
            }
        }
        map.mapItems = new MapItem[nameRemap.Count];
        int c = 0;
        sw.WriteLine(string.Format("\t t.{0} = {{}}",map.gameObject.name));
        sw.WriteLine(string.Format("\t t.{0}.map = t.obj.transform:Find('{1}'):GetComponent(typeof(CS.GameObjectMap))", map.gameObject.name, GetFullSubPath(map)));
        sw.WriteLine(string.Format("\t t.{0}.bind = function(table,map)", map.gameObject.name));
        foreach (var k in nameRemap)
        {
            string name = k.Value.Replace(" ","").Replace("(", "").Replace(")", "");

            map.mapItems[c] = new MapItem();
            map.mapItems[c].name = name;
            map.mapItems[c].go = k.Key.gameObject;
            

            sw.WriteLine(string.Format(template, name, k.Key.GetType().Name));

            c++;
        }
        sw.WriteLine("\t end");
        sw.WriteLine(string.Format("\t t.{0}.bind(t.{0},t.{0}.map)", map.gameObject.name));

        EditorUtility.SetDirty(target);
        AssetDatabase.SaveAssets();

    }
}