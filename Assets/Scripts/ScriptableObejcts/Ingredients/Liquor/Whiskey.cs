using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rum", menuName = "Ingredients/Liquor/Gin")]
public class Whiskey : Liquor
{
    public enum WhiskeyRegion 
    {
        Scotch,
        Irish,
        Bourbon
    }

    public enum WhiskeyIngredient
    {
        Malt,
        Grain
    }

    protected override void OnEnable() {
        base.OnEnable();
        this.liquorType = LiquorType.Whiskey;
    }

    // public bool 
}