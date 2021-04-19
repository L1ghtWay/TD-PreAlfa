using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public new string name;
    public string type;

    public float speed;
    public int damage;
    public int health;
    
}
