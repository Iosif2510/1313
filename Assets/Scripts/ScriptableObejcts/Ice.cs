using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ice", menuName = "Ingredients/Ice", order = 0)]
public class Ice : Ingredient
{
    // 얼음 1개 부피
    public float size;
    protected override void OnEnable()
    {
        this.ingredientType = IngredientType.Ice;
    }
}