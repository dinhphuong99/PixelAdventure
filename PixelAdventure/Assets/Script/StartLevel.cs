using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private int level;
    public void StartGame()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
