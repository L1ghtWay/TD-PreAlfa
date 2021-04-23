using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "Tower")]
[SerializeField] 
public class Tower : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    
    public int cost;
    public int damage;

    public float range;
    public float attackSpeed;
}
