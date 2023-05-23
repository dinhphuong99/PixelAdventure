using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenNewScene : MonoBehaviour
{
    [SerializeField] private string NewScene;
    public void OpenScene()
    {
        SceneManager.LoadScene(NewScene);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
