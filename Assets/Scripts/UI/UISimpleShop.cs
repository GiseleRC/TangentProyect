using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISimpleShop : MonoBehaviour
{
    [SerializeField] private Button _openShopButton;
    [SerializeField] private Button _closeShopButton;
    [SerializeField] private Button _shopAvatarDefault0;
    [SerializeField] private Button _shopAvatar1;
    [SerializeField] private Button _shopAvatar2;
    [SerializeField] private Button _shopAvatar3;

    [SerializeField] private GameObject _shopOptionArea;
    [SerializeField] private GameObject _optionContainer;
    [SerializeField] private GameObject _avatarDefault;
    [SerializeField] private GameObject _avatar1;
    [SerializeField] private GameObject _avatar2;
    [SerializeField] private GameObject _avatar3;

    private int _avatarDefaultIndex = 0;
    private int _avatar1Index = 1;
    private int _avatar2Index = 2;
    private int _avatar3Index = 3;

    private void Start()
    {
        GameManager.Instance.PersistentData.OnOrbsChanged += EnableButtonsToShop;
        GameManager.Instance.PersistentData.OnAvatarChanged += EnableAvatar;

        EnableButtonsToShop(GameManager.Instance.PersistentData.Orbs);
        EnableAvatar(GameManager.Instance.PersistentData.CurrentAvatar);

        _openShopButton.onClick.AddListener(OpenShop);
        _closeShopButton.onClick.AddListener(CloseShop);

    }
    private void OnDestroy()
    {
        GameManager.Instance.PersistentData.OnOrbsChanged -= EnableButtonsToShop;
        GameManager.Instance.PersistentData.OnAvatarChanged -= EnableAvatar;
    }

    private void EnableButtonsToShop(int orbs)
    {
        if (orbs >= 500)
        {
            _shopAvatarDefault0.interactable = true;
            _shopAvatar1.interactable = true;
            _shopAvatar2.interactable = true;
            _shopAvatar3.interactable = true;
        }
        else
        {
            _shopAvatarDefault0.interactable = true;
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

    private void EnableAvatar(int avatarIndex)
    {
        if (avatarIndex == _avatarDefaultIndex)
        {
            _avatarDefault.SetActive(true);
            _avatar1.SetActive(false);
            _avatar2.SetActive(false);
            _avatar3.SetActive(false);
        }
        else if (avatarIndex == _avatar1Index)
        {
            _avatarDefault.SetActive(false);
            _avatar1.SetActive(true);
            _avatar2.SetActive(false);
            _avatar3.SetActive(false);
        }
        else if (avatarIndex == _avatar2Index)
        {
            _avatarDefault.SetActive(false);
            _avatar1.SetActive(false);
            _avatar2.SetActive(true);
            _avatar3.SetActive(false);
        }
        else if (avatarIndex == _avatar3Index)
        {
            _avatarDefault.SetActive(false);
            _avatar1.SetActive(false);
            _avatar2.SetActive(false);
            _avatar3.SetActive(true);
        }
    }

    public void ShopAvatar(int avatarIndex)
    {
        EnableButtonsToShop(GameManager.Instance.PersistentData.Orbs);

        if (avatarIndex == 0  && GameManager.Instance.PersistentData.CurrentAvatar != 0)
        {
            EnableAvatar(avatarIndex);
            GameManager.Instance.PersistentData.CurrentAvatar = avatarIndex;
            GameManager.Instance.SavePersistentData();
        }
        else if (avatarIndex != GameManager.Instance.PersistentData.CurrentAvatar && GameManager.Instance.PersistentData.Orbs >= 500)
        {
            GameManager.Instance.PersistentData.Orbs -= 500;
            EnableAvatar(avatarIndex);
            GameManager.Instance.PersistentData.CurrentAvatar = avatarIndex;
            GameManager.Instance.SavePersistentData();
        }
    }
}
