using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects; // Array of game objects to be destroyed
    
    private int remainingObjects;
    public GameObject winPanel;
    public Button home, nextLevel, ighome;

    void Start()
    {
        winPanel.SetActive(false);
        home.onClick.AddListener(Home);
        nextLevel.onClick.AddListener(Next);
        ighome.onClick.AddListener(IgHome);
        // Initialize the count of remaining game objects to be destroyed
        remainingObjects = gameObjects.Length;

        // Attach the "DestroyableObject" script to each game object in the array
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].AddComponent<DestroyableObject>();
            gameObjects[i].GetComponent<DestroyableObject>().gameController = this;
        }
    }

    void Home()
    {
        SceneManager.LoadScene("Start Menu");
    }

    void Next()
    {
        GameManager.instance.LoadNextLevel();
    }

    void IgHome()
    {
        SceneManager.LoadScene("Start Menu");
    }

    // This function is called when a game object is destroyed
    public void GameObjectDestroyed()
    {
        remainingObjects--;

        if (remainingObjects == 0)
        {
            LoadWinScene();
        }
    }

    void LoadWinScene()
    {
        ighome.gameObject.SetActive(false);
        winPanel.SetActive(true);
    }
}

public class DestroyableObject : MonoBehaviour
{
    public GameController gameController;

    void OnDestroy()
    {
        if (gameController != null)
        {
            gameController.GameObjectDestroyed();
        }
    }
}
