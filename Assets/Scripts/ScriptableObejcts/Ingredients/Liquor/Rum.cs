using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rum", menuName = "Ingredients/Liquor/Rum", order = 1)]
public class Rum : Liquor 
{

    public enum RumColor 
    {
        White, Gold, Dark
    }

    public RumColor color;
    public bool overproof;
    public bool flavored;
    public bool spiced;

    protected override void OnEnable() 
    {
        base.OnEnable();
        this.liquorType = LiquorType.Rum;
    }
    
}