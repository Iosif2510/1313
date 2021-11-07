using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContainerObject : MonoBehaviour, IPointerClickHandler
{
    public BarServeManager barServeManager;
    public Container currentContainer;
    private Image containerImage;

    // public List<(ScriptableObject, float)> containerList = new List<(ScriptableObject, float)>();
    public List<Dictionary<Ingredient, float>> ingredientList = new List<Dictionary<Ingredient, float>>();
    public List<Technique> techniqueList = new List<Technique>();
    public List<Garnish> garnishList;

    public float blandness;
    public float smoothness;

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
    private int currentAmount;   // 현재 담긴 양
    [SerializeField]
    private int fullAmount;      // 잔의 총 용량

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
        if (Input.GetKey(KeyCode.Space))
        {
            PrintContainer();
        }
    }

    public float Pour(Ingredient ingredient, float amount)
    {
        //* 부은 진짜 양을 리턴
        if (currentAmount == fullAmount)
        {
            // 잔이 꽉 찼을 경우
            //TODO 용량부족
            return -1;
        }
        if (currentAmount + amount > fullAmount)
        {
            // 따르라는 양이 빈 용량보다 많은 경우, 빈 용량만큼만 따르기
            //// containerList.Add((ingredient, fullAmount - currentAmount));
            currentIngredients.Add(ingredient, fullAmount - currentAmount);
            return (fullAmount - currentAmount);
        }
        else
        {
            // // containerList.Add((ingredient, amount));
            currentIngredients.Add(ingredient, amount);
            return amount;
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

    void CheckRecipe()
    {

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
}
