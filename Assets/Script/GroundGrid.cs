﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGrid : MonoBehaviour
{
    public Vector2Int size = Vector2Int.one;

    private void OnDrawGizmos()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0,1,0,.3f);
                else Gizmos.color = new Color(1, 0, 0, .3f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }    
}
