using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject profileManager;

    [SerializeField] GameObject profileMenuParent;

    public void DisplayProfileSelectionMenu(bool value) //Affiche le menu selon actif ou non
    {
        profileManager.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void DisplayMainMenu(bool value)
    {
        profileManager.SetActive(false);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void DisplayOptionsMenu(bool value)
    {
        profileManager.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
