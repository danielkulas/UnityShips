/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject options;


    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void toOptions()
    {
        options.SetActive(true);
        menu.SetActive(false);
    }

    public void backToMenu()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }
}