using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private void OnEnable()
    {
        Hole.FallInTheHole += Reload;
    }

    private void OnDisable()
    {
        Hole.FallInTheHole -= Reload;
    }

    // Start is called before the first frame update
    public void Reload(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
