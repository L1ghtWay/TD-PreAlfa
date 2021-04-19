using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private Transform cannon;

    private FlyingTowerBehaviour flyingTower;
    private bool enemyInAttackRange;
    private Transform enemy;
    
    void Awake()
    {
        
    }

    private void Start()
    {
        flyingTower = gameObject.GetComponent<FlyingTowerBehaviour>();      
    }
    
    void Update()
    {
        if (enemy != null) cannon.LookAt(enemy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(flyingTower.towerIsPlaced && other.CompareTag("Enemy"))
        {
            enemy = other.transform;
        }
    }
}
