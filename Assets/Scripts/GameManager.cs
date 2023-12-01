using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentLevel = 0;
    int coin;
    public TMP_Text cointext;
    public GameObject settingpannel;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        
   
    }
    public void settingbutton()
    {
        settingpannel.SetActive(true);
    }
    public void settingbuttoff()
    {
        settingpannel.SetActive(false);
    }
    private void Start()
    {
        //coin = PlayerPrefs.GetInt("coins", 0);
        //cointext.text = coin.ToString();
        currentLevel = PlayerPrefs.GetInt("Currentlevel", 1);
    }
    public void levelbtn(int n)
    {
        currentLevel = n;
    }
    public void playlevel()
    {
        SceneManager.LoadScene("Level " + currentLevel);
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
    private void OnEnable()
    {
        coin = PlayerPrefs.GetInt("coins", 0);
        cointext.text = coin.ToString();
    }
}
