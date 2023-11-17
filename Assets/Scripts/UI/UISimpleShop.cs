using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISimpleShop : MonoBehaviour
{
    [SerializeField] private Button _openShopButton;
    [SerializeField] private Button _closeShopButton;
    [SerializeField] private Button _shopAvatar1;
    [SerializeField] private Button _shopAvatar2;
    [SerializeField] private Button _shopAvatar3;

    [SerializeField] private GameObject _shopOptionArea;
    [SerializeField] private GameObject _optionContainer;
    [SerializeField] private GameObject _avatarDefault;
    [SerializeField] private GameObject _avatar1;
    [SerializeField] private GameObject _avatar2;
    [SerializeField] private GameObject _avatar3;

    [SerializeField] private UIOrbs _uiOrbs;

    private void Start()
    {
        GameManager.Instance.PersistentData.OnOrbsChanged += EnableButtonsToShop;

        EnableButtonsToShop(GameManager.Instance.PersistentData.Orbs);

        if (GameManager.Instance.PersistentData.CurrentAvatar == null)//funca
        {
            GameManager.Instance.PersistentData.CurrentAvatar = _avatarDefault;
            GameManager.Instance.PersistentData.CurrentAvatar.SetActive(true);
        }

        _openShopButton.onClick.AddListener(OpenShop);
        _closeShopButton.onClick.AddListener(CloseShop);

    }
    private void OnDestroy()
    {
        GameManager.Instance.PersistentData.OnOrbsChanged -= EnableButtonsToShop;
    }

    private void EnableButtonsToShop(int orbs)
    {
        if (orbs >= 500)
        {
            _shopAvatar1.interactable = true;
            _shopAvatar2.interactable = true;
            _shopAvatar3.interactable = true;
        }
        else
        {
            _shopAvatar1.interactable = false;
            _shopAvatar2.interactable = false;
            _shopAvatar3.interactable = false;
        }
    }

    private void OpenShop()
    {
        _shopOptionArea.SetActive(true);
        _optionContainer.SetActive(false);
    }

    private void CloseShop()
    {
        _shopOptionArea.SetActive(false);
        _optionContainer.SetActive(true);
    }

    public void ShopAvatar(GameObject avatar)
    {
        EnableButtonsToShop(GameManager.Instance.PersistentData.Orbs);

        if (avatar != GameManager.Instance.PersistentData.CurrentAvatar && GameManager.Instance.PersistentData.Orbs >= 500)
        {
            GameManager.Instance.PersistentData.Orbs -= 500;

            GameManager.Instance.PersistentData.CurrentAvatar.SetActive(false);
            GameManager.Instance.PersistentData.CurrentAvatar = avatar;
            GameManager.Instance.PersistentData.CurrentAvatar.SetActive(true);

            _uiOrbs.UpdateUI(GameManager.Instance.PersistentData.Orbs);

            GameManager.Instance.SavePersistentData();
        }
    }

}
