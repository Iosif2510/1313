using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public List<ScriptableObject> recipeList;
    public List<float> recipeAmounts;

    public Glass glass;
    public List<Garnish> garnishList;

    public static int RecipeGrade(Recipe recipe)
    {
        return -1;
    }
}
