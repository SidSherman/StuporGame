using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadJson : MonoBehaviour
{



static public T LoadingJson<T>()
{
    if (File.Exists(Json.path))
    {
        return JsonUtility.FromJson<T>(File.ReadAllText(Json.path));
    }
    else return default(T);

}
}