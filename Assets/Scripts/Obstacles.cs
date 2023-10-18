using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int cost;
    public Node node;

    private void OnMouseDown()
    {
        BuildManager.Instance.RemoveObstacles(this);
        gameObject.SetActive(false);
    }
}
