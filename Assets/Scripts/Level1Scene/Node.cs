using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("*** Optional parameter ***")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    [SerializeField] bool notBuildableNode = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (notBuildableNode)
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null)
            return;

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        rend.material.color = hoverColor;

        if (buildManager.CanBuild)
            return;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
