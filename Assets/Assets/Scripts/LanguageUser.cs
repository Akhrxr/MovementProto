using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageUser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MultiLanguage languageManager = MultiLanguage.instance;
        LocalizationManager.Read();
        LocalizationManager.Language = languageManager.GetSelectedLanguage();
    }

}
