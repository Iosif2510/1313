using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gin", menuName = "Ingredients/Liquor/Gin")]
public class Gin : Liquor
{

    public enum GinType
    {
        LondonDry,
        Genever,
        OldTom
    }

    public GinType ginType;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.liquorType = LiquorType.Gin;
    }

}