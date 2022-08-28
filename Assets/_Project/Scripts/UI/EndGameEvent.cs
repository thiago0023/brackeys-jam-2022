using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            LoadScene();
        }
    }

    private void LoadScene() {
        SceneManager.LoadScene("EndScene");
    }


}
