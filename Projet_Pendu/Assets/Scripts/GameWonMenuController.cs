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
        Instance = this; //instancie le GameWonMenuController d�s le d�marrage
    }

    private void Start()
    {
        SetActive(false); //d�sactive le parent au d�marrage
    }

    public void SetActive(bool active)
    {
        parent.SetActive(active); //S'affiche quand l'�tat IsWon est atteint
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

