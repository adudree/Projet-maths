using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string SceneToLoad;

    void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}