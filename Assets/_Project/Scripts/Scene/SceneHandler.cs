using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneHandler : MonoBehaviour
{
    public static Action ReloadScene;

    private void OnEnable()
    {
        ReloadScene += OnReload;
    }

    private void OnDisable()
    {
        ReloadScene -= OnReload;
    }

    public void OnReload(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
