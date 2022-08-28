using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
   public void Test() {
       Debug.Log("Test");
   }

   public void ShowTutorial() {
    tutorial.SetActive(true);
   }

    public void HideTutorial() {
     tutorial.SetActive(false);
    }

    private void LoadScene() {
        SceneManager.LoadScene("world map");
    }

    public void QuitGame() {
        Application.Quit();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F) ) {
            LoadScene();
        }
    }
}
