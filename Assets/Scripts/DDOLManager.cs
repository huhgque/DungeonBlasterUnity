using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DDOLManager
{
    public static List<GameObject> ddolObject = new();
    public static void AddDDOLObject(GameObject gameObject){
        ddolObject.Add(gameObject);
        GameObject.DontDestroyOnLoad(gameObject);
    }
    public static GameObject FindDDOLObject(string name){
        return DDOLManager.ddolObject.FirstOrDefault(g => g.name == name);
    }
    public static void RemoveDDOLObject(string name){
        GameObject removeObject = FindDDOLObject(name);
        if (removeObject != null)
            ddolObject.Remove(removeObject);
    }
}
