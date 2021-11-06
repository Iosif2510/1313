using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//// [CreateAssetMenu(fileName = "New Liquor", menuName = "Ingredients/Liquor", order = 1)]
public class Liquor : Ingredient
{
    public enum LiquorType
    {
        Gin,
        Rum,
        Vodka,
        Whiskey,
        Brandy,
        Tequila,
        Absinthe,
        Cachaca,
        Soju,
        Wine,
        Liqueur,
        Bitters
    }

    public LiquorType liquorType;
    public int proof;   //200기준
    public int density; //비중, 100기준

    // public int age {get; protected set;}
    protected override void OnEnable()
    {
        this.ingredientType = IngredientType.Liquor;
    }
}