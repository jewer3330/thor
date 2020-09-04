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
    SerializedProperty mapItemsProp;

    void OnEnable()
    {
        mapItemsProp = serializedObject.FindProperty("mapItems");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //if (GUILayout.Button("Rename"))
        //{
        //    List<Object> objs = new List<Object>();

        //    for (int i = 0;i < mapItemsProp.arraySize; i++)
        //    {
        //        var prop = mapItemsProp.GetArrayElementAtIndex(i);
        //        var objProp = prop.FindPropertyRelative("go");
        //        if (objProp.objectReferenceValue)
        //        {
        //            objs.Add(objProp.objectReferenceValue);
        //        }
        //        else
        //        {
        //            //mapItemsProp.DeleteArrayElementAtIndex(i);
        //        }
        //    }

        //    Dictionary<string, int> counter = new Dictionary<string, int>();
        //    Dictionary<Object, string> nameRemap = new Dictionary<Object, string>();
        //    for(int i =0; i < objs.Count;i++)
        //    {
        //        int count;
        //        var r = objs[i];
        //        if (counter.TryGetValue(r.name, out count))
        //        {
        //            counter[r.name] = ++count;
        //            if (!nameRemap.ContainsKey(r)) //同一个物体被反复添加 
        //                nameRemap.Add(r, r.name + "" + count);
        //            else
        //            {
        //                mapItemsProp.DeleteArrayElementAtIndex(i);
        //                counter[r.name] = --count;
        //            }
        //        }
        //        else
        //        {
        //            counter.Add(r.name, 0);
        //            nameRemap.Add(r, r.name);
        //        }
        //    }

        //    for (int i = 0; i < mapItemsProp.arraySize; i++)
        //    {
        //        var prop = mapItemsProp.GetArrayElementAtIndex(i);
        //        var nameProp = prop.FindPropertyRelative("name");
        //        var objProp = prop.FindPropertyRelative("go");

        //        if (objProp.objectReferenceValue)
        //        {
        //            var name = objProp.objectReferenceValue.name;
        //            if (nameRemap.TryGetValue(objProp.objectReferenceValue, out name))
        //            { 
        //                nameProp.stringValue = name;
        //            }
        //        }
        //    }

        //}

        if (GUILayout.Button("Export"))
        {
            uis.Clear();
            Export();
        }

        serializedObject.ApplyModifiedProperties();
    }

    public string exportPath => Application.dataPath + "/LuaScripts/";

    public void Export()
    {
        if (!System.IO.Directory.Exists(exportPath))
        {
            System.IO.Directory.CreateDirectory(exportPath);
        }
        if (target)
        {
            GameObjectMap map = target as GameObjectMap;
            var buttons = map.gameObject.GetComponentsInChildren<Button>(true);
            var images = map.gameObject.GetComponentsInChildren<Image>(true);
            var texts = map.gameObject.GetComponentsInChildren<Text>(true);
            var rawImages = map.gameObject.GetComponentsInChildren<RawImage>(true);
            var toggles = map.gameObject.GetComponentsInChildren<Toggle>(true);
            var sliders = map.gameObject.GetComponentsInChildren<Slider>(true);
            var scrollbars = map.gameObject.GetComponentsInChildren<Scrollbar>(true);
            var dropdowns = map.gameObject.GetComponentsInChildren<Dropdown>(true);
            var inputFields = map.gameObject.GetComponentsInChildren<InputField>(true);

           

            Array.ForEach(buttons, r => Add(r));
            Array.ForEach(images, r => Add(r));
            Array.ForEach(texts, r => Add(r));
            Array.ForEach(rawImages, r => Add(r));
            Array.ForEach(toggles, r => Add(r));
            Array.ForEach(sliders, r => Add(r));
            Array.ForEach(scrollbars, r => Add(r));
            Array.ForEach(dropdowns, r => Add(r));
            Array.ForEach(inputFields, r => Add(r));


            
            using (StreamWriter sw = new StreamWriter(exportPath + target.name + ".lua"))
            {
                sw.WriteLine("local bindings = function(t)");
                sw.WriteLine("\t t.bindings = {}");
                AutoAddMapObject(uis, sw);
                sw.WriteLine("end");
                sw.WriteLine("return bindings");
            }
                
            AssetDatabase.Refresh();
        }
    }

    private string template => "\t t.bindings.{0} = t.map:Get('{0}'):GetComponent(typeof(CS.UnityEngine.UI.{1}))";
    void Add(UIBehaviour button)
    {
        
        uis.Add(button);
    }
    private List<UIBehaviour> uis = new List<UIBehaviour>();
    void AutoAddMapObject(List<UIBehaviour> uis, StreamWriter sw)
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
                counter[ui.name] = ++count;
                if (!nameRemap.ContainsKey(ui)) 
                    nameRemap.Add(ui, key + "" + count);
            }
            else
            {
                counter.Add(key, 0);
                nameRemap.Add(ui, key);
            }
        }
        GameObjectMap map = target as GameObjectMap;
        map.mapItems = new MapItem[nameRemap.Count];
        int c = 0;
        foreach (var k in nameRemap)
        {
            string name = k.Value.Replace(" ","").Replace("(", "").Replace(")", "");

            map.mapItems[c] = new MapItem();
            map.mapItems[c].name = name;
            map.mapItems[c].go = k.Key.gameObject;
            

            sw.WriteLine(string.Format(template, name, k.Key.GetType().Name));

            c++;
        }

        EditorUtility.SetDirty(target);
        AssetDatabase.SaveAssets();

    }
}