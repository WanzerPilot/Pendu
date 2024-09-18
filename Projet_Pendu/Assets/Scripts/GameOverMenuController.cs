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
        Instance = this; //instancie le GameOverMenuController dès le démarrage
    }

    private void Start()
    {
        SetActive(false); //désactivé au démarrage d'une partie
    }

    public void SetActive(bool active)
    {
        parent.SetActive(active); //S'affiche quand l'état IsLost est rencontré
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
