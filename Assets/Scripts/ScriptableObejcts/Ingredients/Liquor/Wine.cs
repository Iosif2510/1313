using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wine", menuName = "Ingredients/Liquor/Wine")]
public class Wine : Liquor
{
    public enum Fruit
    {
        Grape,
        Berry
    }

    public enum WineColor
    {
        Red,
        White
    }

    public Fruit wineFruit;
    public WineColor wineColor;
    public bool fortified;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.liquorType = LiquorType.Wine;
    }

}