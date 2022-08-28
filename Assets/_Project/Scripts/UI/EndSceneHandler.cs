using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneHandler : MonoBehaviour
{
    [SerializeField] private float timeToChangeScene = 5f;

    // Update is called once per frame
    void Update()
    {
        timeToChangeScene -= Time.deltaTime;
        if (timeToChangeScene <= 0) {
            LoadScene();
        }

        if(Input.GetKeyDown(KeyCode.F)) {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
