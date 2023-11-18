using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Node node;

    private void OnMouseDown()
    {
        if (Shop.Instance.obstaclesStats.axeSelected)
        {
            BuildManager.Instance.RemoveObstacles(this);
            gameObject.SetActive(false);
            Shop.Instance.obstaclesStats.axeSelected = false;
        }
    }
}
