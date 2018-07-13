using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour {
    float time = 10.0f;

    void Start ()
    {}
	
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
        }
    }
}
