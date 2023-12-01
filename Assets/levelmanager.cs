using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelmanager : MonoBehaviour
{
    public Button[] button;
    int currentlevel;
    public Sprite locksprite,unlocksprite;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
        }
        currentlevel = PlayerPrefs.GetInt("Currentlevel", 1);
        for (int i = 0; i < 50; i++)
        {
            button[i].interactable = false;
            button[i].GetComponent<Image>().sprite = locksprite;
        }
        for (int i = 0; i < currentlevel; i++)
        {
            button[i].interactable = true;
            button[i].GetComponent<Image>().sprite = unlocksprite;
        }
    }

   

}
