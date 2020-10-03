using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJson : MonoBehaviour
{



static public void SaveFileJson(object obj)
    {
        File.WriteAllText(Json.path, JsonUtility.ToJson(obj));
    }
    

}