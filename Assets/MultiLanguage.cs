using Assets.SimpleLocalization.Scripts;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLanguage : MonoBehaviour
{
    public static MultiLanguage instance;
    public GameObject gameObj;
    private string selectedLanguage = "English";

    void Awake()
    {
        LocalizationManager.Read();
        LocalizationManager.Language = selectedLanguage;
        // Ensure only one instance of the LanguageManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameObject from being destroyed
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void Language(string language)
    {
        selectedLanguage = language;
        LocalizationManager.Language = selectedLanguage; 
    }
    public string GetSelectedLanguage()
    {
        return selectedLanguage;
    }

    public void SetSelectedLanguage(string language)
    {
        selectedLanguage = language;
        LocalizationManager.Language = selectedLanguage;
    }
}
