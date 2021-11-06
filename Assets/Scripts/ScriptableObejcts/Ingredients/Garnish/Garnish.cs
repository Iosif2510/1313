using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GarnishType
{
    Citrus,
    Olive,
    Herb
}

[CreateAssetMenu(fileName = "New Garnish", menuName = "Ingredients/Garnish")]
public class Garnish : Ingredient
{
    public GarnishType garnishType;

    protected override void OnEnable()
    {
        this.ingredientType = IngredientType.Garnish;
    }
}