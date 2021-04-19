using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerDisplay : MonoBehaviour
{
    public Tower tower;

    public Text nameText;
    public Text damageText;
    public Text costText;
    public Text rangeText;
    public Text attackSpeedText;

    public Image artworkImage;
    
    void Start()
    {
        nameText.text = tower.name;
        damageText.text = $"Damage: {tower.damage}";
        costText.text = $"Cost: {tower.cost}";
        rangeText.text = $"Attack range: {tower.range}";
        attackSpeedText.text = $"Attack speed: {tower.attackSpeed}";

        artworkImage.sprite = tower.sprite;
    }    
}
