using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void Update()
    {

    }

    private void OnTouchDown()
    {
        if (turret != null)
        {
            Debug.Log("sedcsdc");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    private void OnTouchEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnTouchExit()
    {
        rend.material.color = startColor;
    }
}
