using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentLevel = 0;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene("Level " + currentLevel);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level " + currentLevel);
    }
}
