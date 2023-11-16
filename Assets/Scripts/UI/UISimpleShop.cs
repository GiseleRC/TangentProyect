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

    private void Start()
    {
        _openShopButton.onClick.AddListener(OpenShop);
        _closeShopButton.onClick.AddListener(CloseShop);
        //_openShopButton.onClick.AddListener(ShopAvatar);
        //_closeShopButton.onClick.AddListener(CloseShop);
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

    private void ShopAvatar(GameObject avatar)
    {

    }


}
