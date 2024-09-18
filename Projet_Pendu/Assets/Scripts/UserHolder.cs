using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserHolder : MonoBehaviour
{
    public static UserHolder Instance;
    public Profile currentProfile;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance.gameObject);
    }

    public Profile CreateNewProfile(string userName)
    {
        Profile newProfile = new Profile(userName); //Appelle constructeur
        SaveProfileOnDisk(newProfile);
        return newProfile;
    }

    public void SaveProfileOnDisk(Profile profile)
    {
        if ( profile.name == string.Empty)
        {
            return;
        }
        string profileData = JsonUtility.ToJson(profile);
        string path = Application.dataPath + "/Profiles/" + profile.name + ".txt";
        File.WriteAllText(path, profileData);

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
        //permet de créer un profil dans Unity pour tests
#endif
    }

    public void SaveCurrentProfileOnDisk()
    {
        if (currentProfile == null) return;
        SaveProfileOnDisk(currentProfile);
    }

    public List<string> GetAllProfiles()
    {
        string path = Application.dataPath + "/Profiles/";
        string[] filePathArray = Directory.GetFiles(path, "*.txt"); // * qui se termine par .txt

        List<string> profilesData = new List<string>();

        foreach (string filePath in filePathArray)
        {

            StreamReader streamReader = File.OpenText(filePath);
            profilesData.Add(streamReader.ReadToEnd());

        }
        return profilesData;
    }

        public void SetCurrentProfile(Profile profile)
        {
            currentProfile = profile;
        }

    public void SetUserScore(int newScore)
    {
        currentProfile.currentScore = newScore;
    }

    public void SetUserBestScore(int newBestScore)
    {
        currentProfile.bestScore = newBestScore;
    }


}
