using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] int currentLevel = 1;
    [SerializeField] Image image;
    [SerializeField] Sprite faddedBackground;
    void Start()
    {
        if(currentLevel != 1)
        {
            if (!isCuurentLevelUnlocked())
            {
                image.sprite = faddedBackground;
            }
        }
        
    }

    bool isCuurentLevelUnlocked()
    {
        Debug.Log(PlayerPrefs.GetInt("LastPLayedLevel"));
        return PlayerPrefs.GetInt("LastPLayedLevel") >= currentLevel;
    }

    // Update is called once per frame
    public void LoadThisLevel()
    {
        if (isCuurentLevelUnlocked() || currentLevel == 1)
        {   
            SceneManager.LoadScene(currentLevel);
        }
    }
}
