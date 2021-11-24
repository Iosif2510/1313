using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipeGrade : MonoBehaviour
{
    public ContainerObject container;

    private List<Dictionary<Ingredient, float>> ingredientList;
    private List<Technique> techniqueList;
    private List<Garnish> garnishList;
    private Glass currentGlass;

    // private float blandness;
    // private float smoothness;

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

    public float GradeRecipe(Recipe recipe)
    {
        //* 점수
        float recipeGrade = 0;

        //* recipe recipeList에서 technique가 존재하는 인덱스
        int techniqueIndex = -1;
        //* ingredientList의 index, Recipe에서 technique 나올때마다 1 증가
        int dictionaryIndex = 0;
        //* 현재 재료-용량 dictionary의 키 목록(ingredient 목록), 리스트 비교에 사용
        List<Ingredient> dictionaryKeyList = new List<Ingredient>(ingredientList[dictionaryIndex].Keys);
        //* 기법 - 기법 사이 Recipe의 재료 목록
        List<ScriptableObject> recipeIngredientsBetween;
        for (int recipeIndex = 0; recipeIndex < recipe.RecipeList.Count; recipeIndex++)
        {
            var recipeMember = recipe.RecipeList[recipeIndex];
            if (recipeMember.GetType() == typeof(Technique))
            {
                //TODO 레시피에 없는 재료가 들어감. 감점
                recipeIngredientsBetween = recipe.RecipeList.GetRange(techniqueIndex + 1, (recipeIndex - techniqueIndex - 1));
                var ingredientsNotNeeded = dictionaryKeyList.Except(recipeIngredientsBetween);
                if (ingredientsNotNeeded.Any())
                {
                    Debug.Log($"Ingredient Not Needed");
                    foreach (var useless in ingredientsNotNeeded)
                    {
                        //TODO 각 재료마다 감점
                    }
                }

                //techniqueList 비교
                if (techniqueList.Count <= dictionaryIndex)
                {
                    //TODO 다음 기법이 아예 없을 경우 감점
                    Debug.Log("Technique Not Found");
                }
                else if (techniqueList[dictionaryIndex] == recipeMember)
                {

                }
                else
                {
                    //TODO 기법이 다를 경우 감점
                }

                techniqueIndex = recipeIndex;

                if (dictionaryIndex + 1 >= ingredientList.Count)
                {
                    if (recipeIndex < recipe.RecipeList.Count - 1)
                    {
                        //TODO 기법 사용 다음 재료가 통째로 없을 경우 감점
                    }
                    else break;     // 레시피와 컨테이너 모두 마지막
                }
                else dictionaryIndex++;
                dictionaryKeyList = new List<Ingredient>(ingredientList[dictionaryIndex].Keys);
                Debug.Log($"Technique: {recipeMember.ToString()}");
            }
            else
            {
                float pouredAmount;
                if (ingredientList[dictionaryIndex].TryGetValue((Ingredient)recipeMember, out pouredAmount))
                {
                    //TODO 레시피 양과 실제 양 비교, 채점
                    Debug.Log($"Ingredient: {recipeMember.ToString()}, {pouredAmount}ml");
                    Debug.Log($"Recipe: {recipeMember.ToString()}, {recipe.RecipeAmounts[recipeIndex]}ml");

                    //// Debug.Log(recipeMember.GetType());
                    //// Debug.Log(((Liquor)recipeMember).liquorType);
                }
                else
                {
                    //TODO 레시피에 필요한 재료가 없음, 감점
                    Debug.Log($"Ingredient Needed: {recipeMember.ToString()}");
                }

            }


        }

        return recipeGrade = 0;
    }
}
