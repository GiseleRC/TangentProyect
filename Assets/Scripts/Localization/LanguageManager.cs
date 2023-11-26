using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public enum Language
{
    en,
    es
}
public class LanguageManager : PersistentSingleton<LanguageManager>
{
    [SerializeField] private string _webURL;

    [SerializeField] private Language _currentLang;

    private Dictionary<Language, Dictionary<string, string>> _languageManager;

    public event Action OnLanguageChanged = delegate { };

    public override void Awake()
    {
        base.Awake();

        StartCoroutine(DownloadTSV(_webURL));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _currentLang = _currentLang == Language.en ? Language.es : Language.en;

            OnLanguageChanged();
        }
    }

    IEnumerator DownloadTSV(string url)
    {
        var www = new UnityWebRequest(url);

        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        _languageManager = LanguageSplit.LoadCodexFromString("www", www.downloadHandler.text);

        OnLanguageChanged();
    }

    public string GetTranslate(string ID)
    {
        if (_languageManager == null || !_languageManager[_currentLang].ContainsKey(ID)) return ID;

        return _languageManager[_currentLang][ID];
    }
}