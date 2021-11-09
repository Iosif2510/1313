using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipeGrade : MonoBehaviour
{
    public ContainerObject container;

    private List<Dictionary<Ingredient, float>> ingredientList;
    private List<Technique> techniqueList;
    private List<Garnish> garnishList;
    private Glass currentGlass;

    private float blandness;
    private float smoothness;

    [SerializeField]
    private Recipe testRecipe;

    void Awake()
    {
        container = this.gameObject.GetComponent<ContainerObject>();

        ingredientList = container.ingredientList;
        techniqueList = container.techniqueList;
        garnishList = container.garnishList;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GradeRecipe(testRecipe);
        }
    }

    public int GradeRecipe(Recipe recipe)
    {
        blandness = container.blandness;
        smoothness = container.smoothness;


        int dictionaryIndex = 0;
        for (int recipeIndex = 0; recipeIndex < recipe.RecipeList.Count; recipeIndex++)
        {
            var asset = recipe.RecipeList[recipeIndex];
            if (asset.GetType() == typeof(Technique))
            {
                dictionaryIndex++;
                //TODO techniqueList 비교
                Debug.Log($"Technique: {asset.ToString()}");
            }
            else
            {
                if (ingredientList[dictionaryIndex].ContainsKey((Ingredient)asset))
                {
                    //TODO 레시피 양과 실제 양 비교, 채점
                    Debug.Log($"Ingredient: {asset.ToString()}, {ingredientList[dictionaryIndex][(Ingredient)asset]}ml");
                    Debug.Log($"Recipe: {asset.ToString()}, {recipe.RecipeAmounts[recipeIndex]}ml");

                    Debug.Log(asset.GetType());
                    Debug.Log(((Liquor)asset).liquorType);

                }
                else
                {
                    //TODO 레시피에 필요한 재료가 없음, 감점
                    Debug.Log($"Ingredient Not Needed: {asset}");
                }
            }
        }

        return -1;
    }
}
