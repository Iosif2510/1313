using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public LiquorType Base;

    [SerializeField]
    private List<ScriptableObject> recipeList;
    [SerializeField]
    private List<float> recipeAmounts;

    [SerializeField]
    private Glass glass;
    [SerializeField]
    private List<Garnish> garnishList;


    public List<ScriptableObject> RecipeList
    {
        get
        {
            return recipeList;
        }
    }
    public List<float> RecipeAmounts
    {
        get
        {
            return recipeAmounts;
        }
    }
    public Glass GlassAsset
    {
        get
        {
            return glass;
        }
    }
    public List<Garnish> GarnishList
    {
        get
        {
            return garnishList;
        }
    }
}
