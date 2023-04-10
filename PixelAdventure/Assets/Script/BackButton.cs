using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField] private string sceneBack;
    public void OpenBackScene()
    {
        SceneManager.LoadScene(sceneBack);
    }
}
