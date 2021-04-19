using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreate : MonoBehaviour
{
    public Vector2Int gridSize = new Vector2Int(10,10);
        
    private FlyingTowerBehaviour[,] grid;    
    private FlyingTowerBehaviour flyingTower;
    private Camera mainCamera;

    private void Awake()
    {
        grid = new FlyingTowerBehaviour [gridSize.x, gridSize.y];
        mainCamera = Camera.main;
    }

    public void StartPlacingTower(FlyingTowerBehaviour towerPrefab)
    {
        if (flyingTower != null)
        {
            Destroy(flyingTower.gameObject);
        }
        flyingTower = Instantiate(towerPrefab);        
    }   

    void Update()
    {
        if (flyingTower != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);                

                flyingTower.transform.position = new Vector3(x, 0, y);                
                flyingTower.SetTrancparent(Available(x,y));

                if(Available(x,y) && IsPlaceFree(x, y) && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingTower(x,y);                   
                }
            }
        }
    }

    private void PlaceFlyingTower(int placeX, int placeY)
    {        
        for (int x = 0; x < flyingTower.gridSize.x; x++)
        {
            for (int y = 0; y < flyingTower.gridSize.y; y++)
            {
                grid[placeX + x, placeY + y] = flyingTower; 
            }
        }

        flyingTower.towerIsPlaced = true;
        flyingTower.SetNormal();        
        flyingTower = null;
    }

    private bool IsPlaceFree (int placeX, int placeY)
    {
        for (int x = 0; x < flyingTower.gridSize.x; x++)
        {
            for (int y = 0; y < flyingTower.gridSize.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return false;
            }
        }
        return true;
    }

    private bool Available (int x, int y)
    {           
        if (x > 0 && x % 3 != 0 && x < 9 && y > 0 && y % 3 != 0 && y < 9)
        {
            if(x == 4 || x ==5)
            {
                if (y == 1 || y == 8) return false;
                else return true;
            }

            if (x == 1 || x == 8)
            {
                if (y == 4 || y == 5) return false;
                else return true;
            }

            else return true;
        }
        else return false;        
    }
}
