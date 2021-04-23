using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTowerBehaviour : MonoBehaviour
{
    public Renderer [] mainRenderer;
    public Vector2Int gridSize = Vector2Int.one;
    public bool towerIsPlaced;
    
    public void SetTrancparent (string color)
    {
        for (int i = 0; i < mainRenderer.Length; i++)
        {
            if (color == "Green")
            {
                mainRenderer[i].material.color = Color.green;
            }
            else mainRenderer[i].material.color = Color.red;
        }
    }    

    public void SetNormal ()
    {
        for (int i = 0; i < mainRenderer.Length; i++)
        {           
            mainRenderer[i].material.color = Color.white;            
        }
    }
    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0, 1, 0, .3f);
                else Gizmos.color = new Color(1, 0, 0, .3f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }    
}
