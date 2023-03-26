using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    AudioSource finishSound;
    bool levelCompleted = false;
                    
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;
            finishSound.Play();
            Invoke("CompleteLevel", 2f);
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

    private void CompleteLevel()
    {
        int lastPLayedLevel = PlayerPrefs.GetInt("LastPLayedLevel");
        int currentLvl = SceneManager.GetActiveScene().buildIndex;
        if(lastPLayedLevel <= currentLvl)
        {
            PlayerPrefs.SetInt("LastPLayedLevel", currentLvl + 1);
        }
        SceneManager.LoadScene(currentLvl + 1);
    }
}
