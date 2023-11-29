using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public int time;

    private void Start()
    {
        AnimateBar();
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time).setOnComplete(LoadNewScene);
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
