using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class Json : MonoBehaviour
{

    static public string path;

    [Serializable]
    public class Data
    {
        public string name;
        public int number;

        public Vector3 pos;
        public Quaternion rot;
    }
    [SerializeField] Data data;

    private void Start() 

    {

        path = Path.Combine(Application.dataPath + transform.gameObject.name, "Save.json");
        data = LoadJson.LoadingJson<Data>();
    }
    void OnApplicationQuit(){
        SaveJson.SaveFileJson(data);
    }
}