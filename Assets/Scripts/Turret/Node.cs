using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private bool _notBuildableNode = false;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _noMoneyColor;
    //[SerializeField] private GameObject _obstacles;
    private Renderer _rend;
    private Color _startColor;

    [Header("*** Optional parameter ***")]
    public GameObject turret;
    public Vector3 positionOffset;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }

    private void Update()
    {
        //if (_notBuildableNode ==  true)
        //{
        //    _obstacles.SetActive(true);
        //}
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_notBuildableNode)
            return;

        if (!BuildManager.Instance.CanBuild)
            return;

        if (turret != null)
            return;

        BuildManager.Instance.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.Instance.CanBuild)
            return;

        if (BuildManager.Instance.HasMoney)
        {
            _rend.material.color = _hoverColor;
        }
        else
        {
            _rend.material.color = _noMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
