/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject UIPauseMenu;
    public Transform SoundManager;
    Component[] audioSources;
    private bool paused = false;
    

    void Start()
    {
        audioSources = SoundManager.GetComponents(typeof(AudioSource));
    }

    private void Update()
    { 
        if (Input.GetButtonDown("Esc"))
        {
            if (paused == false)
                pause();
            else
                resume();
        }
    }

    public void pause()
    {
        UIPauseMenu.SetActive(true);
        Time.timeScale = 0;
        foreach (AudioSource audio in audioSources) //Mute sounds
            audio.Pause();

        paused = true;
    }

    public void resume()
    {
        foreach (AudioSource audio in audioSources) //Unmute sounds
            audio.Play();

        Time.timeScale = 1;
        UIPauseMenu.SetActive(false);
        paused = false;
    }


    //Buttons
    public void quit()
    {
        Application.Quit();
    }

    public void toMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void toNewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}