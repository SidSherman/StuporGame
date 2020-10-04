using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverser : MonoBehaviour
{
    void OnPreCull () {
        Camera.main.ResetWorldToCameraMatrix ();
        Camera.main.ResetProjectionMatrix ();
        Camera.main.projectionMatrix = Camera.main.projectionMatrix * Matrix4x4.Scale(new Vector3 (-1, 1, 1));
    }
  
    void OnPreRender () {
        GL.SetRevertBackfacing (true);
    }
  
    void OnPostRender () {
        GL.SetRevertBackfacing (false);
    }
}
