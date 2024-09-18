using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    public static GameOverMenuController Instance;
    [SerializeField] GameObject parent;


    void Awake()
    {
        Instance = this; //instancie le GameOverMenuController d�s le d�marrage
    }

    private void Start()
    {
        SetActive(false); //d�sactiv� au d�marrage d'une partie
    }

    public void SetActive(bool active)
    {
        parent.SetActive(active); //S'affiche quand l'�tat IsLost est rencontr�
    }


    public void Retry()
    {
        SceneManager.LoadScene("MainGame");
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
