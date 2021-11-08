using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Newtonsoft.Json;

public class ContainerObject : MonoBehaviour, IPointerClickHandler
{
    public BarServeManager barServeManager;
    public Container currentContainer;
    private Image containerImage;

    //* Recipe
    public List<Dictionary<Ingredient, float>> ingredientList = new List<Dictionary<Ingredient, float>>();
    public List<Technique> techniqueList = new List<Technique>();
    public List<Garnish> garnishList;

    public float blandness;
    public float smoothness;

    //* RecipeEnd

    // 기법과 기법 사이, 현재 섞을 재료 및 용량
    private Dictionary<Ingredient, float> currentIngredients;

    /*
        레시피의 형성
        ingredientList: Dictionary<재료, 용량> 기법단위로 나눔
        techniqueList: 기법 순서대로 저장
        ingredientList[index]를 넣은 다음 techniqueList[index] 기법 사용
        즉 기법 사용 시 재료가 섞이므로 기법 앞 재료 순서는 무의미
        ㄴ 플로트 기법 사용 시 각 재료 사이마다 기법 객체 더해줘야함
    */


    [SerializeField]
    private float currentAmount;   // 현재 담긴 양
    [SerializeField]
    private float fullAmount;      // 잔의 총 용량

    // Start is called before the first frame update
    void Awake()
    {
        containerImage = this.gameObject.GetComponent<Image>();

        containerImage.sprite = currentContainer.containerSprite;
        fullAmount = currentContainer.containerVolume;

        // ingredientList 초기화
        currentIngredients = new Dictionary<Ingredient, float>();
        ingredientList.Add(currentIngredients);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // PrintContainer();
            Debug.Log(ObjectToJson(ingredientList));
        }
    }

    public float Pour(Ingredient ingredient, float amount)
    {
        //* 부은 진짜 양을 리턴
        if (currentAmount == fullAmount)
        {
            // 잔이 꽉 찼을 경우
            //TODO 용량부족
            Debug.Log("Not Enough Space!");
            return -1;
        }
        if (currentAmount + amount > fullAmount)
        {
            // 따르라는 양이 빈 용량보다 많은 경우, 빈 용량만큼만 따르기
            float pouredAmount = fullAmount - currentAmount;
            AddIngredient(ingredient, pouredAmount);
            return pouredAmount;
        }
        else
        {
            AddIngredient(ingredient, amount);
            return amount;
        }
    }

    private void AddIngredient(Ingredient ingredient, float amount)
    {
        currentAmount += amount;
        if (currentIngredients.ContainsKey(ingredient))
        {
            currentIngredients[ingredient] += amount;
        }
        else
        {
            currentIngredients.Add(ingredient, amount);
        }
    }

    public void AddTechnique(Technique technique, float amount)
    {
        // techniqueList Add
        //TODO 기법의 강도는 bland, smooth 정도를 통해 평가
        techniqueList.Add(technique);

        // make new ingredient Dictionary
        currentIngredients = new Dictionary<Ingredient, float>();
        ingredientList.Add(currentIngredients);

        // calculate blandness, smoothness
        blandness = amount * technique.blandPerSecond;
        smoothness = amount * technique.smoothPerSecond;

        // 시발...이렇게쉬운걸
    }

    public void AddGarnish(Garnish garnish)
    {
        garnishList.Add(garnish);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Container Click");
        barServeManager.Pour();
        // PrintContainer();
    }

    public int GradeRecipe(Recipe recipe)
    {
        int dictionaryIndex = 0;
        for (int recipeIndex = 0; recipeIndex < recipe.RecipeList.Count; recipeIndex++)
        {
            var asset = recipe.RecipeList[recipeIndex];
            if (asset.GetType() == typeof(Technique))
            {
                dictionaryIndex++;
                //TODO techniqueList 비교
            }
            else
            {
                if (ingredientList[dictionaryIndex].ContainsKey((Ingredient)asset))
                {
                    //TODO 레시피 양과 실제 양 비교, 채점
                }
                else
                {
                    //TODO 레시피에 없는 재료 삽입, 감점
                }
            }
        }

        return -1;
    }

    public void PrintContainer()
    {
        for (int i = 0; i < ingredientList.Count; i++)
        {
            foreach (var ingredient in ingredientList[i])
            {
                Debug.Log($"{ingredient.Key.ToString()}: {ingredient.Value}ml");
            }
            if (i < techniqueList.Count)
            {
                Debug.Log(techniqueList[i].ToString());
            }
        }
    }

    public string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}
