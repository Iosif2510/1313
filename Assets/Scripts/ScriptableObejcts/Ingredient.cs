using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType
{
    Liquor,
    NonAlcohol,
    Garnish,
    Ice,
    Misc
}

public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public IngredientType ingredientType;
    public Sprite ingredientImage;
    public int grade;   // 1~5점
    public float fullAmount; // 최대용량

    protected virtual void OnEnable()
    {

    }
}

