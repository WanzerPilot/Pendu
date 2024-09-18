using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonMenuController : MonoBehaviour
{
    public static GameWonMenuController Instance;
    [SerializeField] GameObject parent;


    void Awake()
    {
        Instance = this; //instancie le GameWonMenuController dès le démarrage
    }

    private void Start()
    {
        SetActive(false); //désactive le parent au démarrage
    }

    public void SetActive(bool active)
    {
        parent.SetActive(active); //S'affiche quand l'état IsWon est atteint
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

