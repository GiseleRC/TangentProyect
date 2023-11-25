using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTranslate : MonoBehaviour
{
    [SerializeField] private string _ID;
    [SerializeField] private TextMeshProUGUI _myText;

    void Start()
    {
        LanguageManager.Instance.OnLanguageChanged += ApplyLocalization;
        ApplyLocalization();
    }

    void OnDestroy()
    {
        LanguageManager.Instance.OnLanguageChanged -= ApplyLocalization;
    }

    private void ApplyLocalization()
    {
        _myText.text = LanguageManager.Instance.GetTranslate(_ID);
    }
}
