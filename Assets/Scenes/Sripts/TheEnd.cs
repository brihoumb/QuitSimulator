using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour {
    public GameObject door;
    public GameObject player;

    void Start()
    {}

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    void OnCollisionEnter(Collision box)
    {
        if (box.gameObject == player)
            SceneManager.LoadScene(2);
    }
}
