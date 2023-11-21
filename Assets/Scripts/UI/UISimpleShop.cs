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

    [SerializeField] private AvatarStats _avatarDefaultStats;
    [SerializeField] private AvatarStats _avatar1Stats;
    [SerializeField] private AvatarStats _avatar2Stats;
    [SerializeField] private AvatarStats _avatar3Stats;

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
        if (avatarIndex == _avatarDefaultStats.AvatarIndex)
        {
            _avatarDefault.SetActive(true);
            _avatar1.SetActive(false);
            _avatar2.SetActive(false);
            _avatar3.SetActive(false);
        }
        else if (avatarIndex == _avatar1Stats.AvatarIndex)
        {
            _avatarDefault.SetActive(false);
            _avatar1.SetActive(true);
            _avatar2.SetActive(false);
            _avatar3.SetActive(false);
        }
        else if (avatarIndex == _avatar2Stats.AvatarIndex)
        {
            _avatarDefault.SetActive(false);
            _avatar1.SetActive(false);
            _avatar2.SetActive(true);
            _avatar3.SetActive(false);
        }
        else if (avatarIndex == _avatar3Stats.AvatarIndex)
        {
            _avatarDefault.SetActive(false);
            _avatar1.SetActive(false);
            _avatar2.SetActive(false);
            _avatar3.SetActive(true);
        }
    }

    public void ShopAvatar(int avatarIndexWanted)
    {
        EnableButtonsToShop(GameManager.Instance.PersistentData.Orbs);

        if (avatarIndexWanted == _avatarDefaultStats.AvatarIndex && GameManager.Instance.PersistentData.CurrentAvatar != _avatarDefaultStats.AvatarIndex)
        {
            EnableAvatar(avatarIndexWanted);
            GameManager.Instance.PersistentData.CurrentAvatar = avatarIndexWanted;
            GameManager.Instance.SavePersistentData();
        }
        else if (avatarIndexWanted != GameManager.Instance.PersistentData.CurrentAvatar)
        {
            if (GameManager.Instance.PersistentData.Orbs >= _avatar1Stats.Price && avatarIndexWanted == _avatar1Stats.AvatarIndex)
            {
                GameManager.Instance.PersistentData.Orbs -= _avatar1Stats.Price;
                EnableAvatar(avatarIndexWanted);
                GameManager.Instance.PersistentData.CurrentAvatar = avatarIndexWanted;
                GameManager.Instance.SavePersistentData();
            }
            else if (GameManager.Instance.PersistentData.Orbs >= _avatar2Stats.Price && avatarIndexWanted == _avatar2Stats.AvatarIndex)
            {
                GameManager.Instance.PersistentData.Orbs -= _avatar2Stats.Price;
                EnableAvatar(avatarIndexWanted);
                GameManager.Instance.PersistentData.CurrentAvatar = avatarIndexWanted;
                GameManager.Instance.SavePersistentData();
            }
            else if (GameManager.Instance.PersistentData.Orbs >= _avatar3Stats.Price && avatarIndexWanted == _avatar3Stats.AvatarIndex)
            {
                GameManager.Instance.PersistentData.Orbs -= _avatar3Stats.Price;
                EnableAvatar(avatarIndexWanted);
                GameManager.Instance.PersistentData.CurrentAvatar = avatarIndexWanted;
                GameManager.Instance.SavePersistentData();
            }
        }
    }
}
