using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLanguage : MonoBehaviour
{
    private void Awake()
    {
        LocalizationManager.Read();

        //LocalizationManager.Language = "English";
        LocalizationManager.Language = "Spanish";
    }
    public void Language(string language)
    {
        LocalizationManager.Language = language;
    }
}
