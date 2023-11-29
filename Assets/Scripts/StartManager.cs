using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public Button start;

    private void Start()
    {
        start.onClick.AddListener(StartBtn);
    }

    private void StartBtn()
    {
        
    }
}
