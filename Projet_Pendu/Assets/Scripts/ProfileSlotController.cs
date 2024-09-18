using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProfileSlotController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI userName, score;
    [SerializeField] Transform newProfileParent, userInfoParent;
    [SerializeField] TMP_InputField userNameInputField;
    [SerializeField] GameObject newProfileButton, creationButton, loadButton, noCharacterMessage;

    [System.NonSerialized]
    public Profile profile;
    public bool isEmpty
    {
        get
        {
            return profile == null;
        }

    }

    void Start()
    {
        noCharacterMessage.SetActive(false); //Désactive le message au démarrage
    }

    void DisplayNewProfileMode()
    {
        newProfileParent.gameObject.SetActive(true);
        userInfoParent.gameObject.SetActive(false);
        userNameInputField.gameObject.SetActive(false);
        newProfileButton.SetActive(true);
        creationButton.SetActive(true);
        loadButton.SetActive(false);
    }

    void DisplayLoadedProfileMode()
    {
        newProfileParent.gameObject.SetActive(false);
        userInfoParent.gameObject.SetActive(true);
        userName.text = profile.name;
        score.text = profile.bestScore.ToString();
        creationButton.SetActive(false);
        loadButton.SetActive(true);
    }

    public void DisplayNewProfileUI()
    {
        userNameInputField.gameObject.SetActive(true);
        newProfileButton.SetActive(false);

    }

    public void CreateNewProfile()
    {
        if (userNameInputField.text.Length == 0)
        {
            noCharacterMessage.SetActive(true);
            //permet d'empêcher de valider un profil vide et d'afficher un message
            return;
        }
        profile = UserHolder.Instance.CreateNewProfile(userNameInputField.text);
        DisplayLoadedProfileMode();
        UpdateInfos();
    }

    public void UpdateInfos()
    {
        userName.text = profile.name;
        score.text = profile.bestScore.ToString();
    }

    public void SetProfileActive()
    {
        UserHolder.Instance.SetCurrentProfile(profile);
        SceneManager.LoadScene("MainGame");
    }

    public void SetProfile(string profileData)
    {
        profile = JsonUtility.FromJson<Profile>(profileData);
        DisplayLoadedProfileMode();
        UpdateInfos();
    }

}
