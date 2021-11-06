using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance = null;

    public CupBoard cupBoard;

    public List<Ingredient> ingredients = new List<Ingredient>();
    public List<float> ingredientsAmount = new List<float>();
    public int maxInvenSize;

    void Awake() {
        if (instance == null) {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }

        ingredients.Capacity = maxInvenSize;
        ingredientsAmount.Capacity = maxInvenSize;
    }

    void Start() {
        //? 타 씬에서 로드 시 작동하지 않을 가능성 있음
        cupBoard = GameObject.FindGameObjectWithTag("CupBoard").GetComponent<CupBoard>();
        
    }

    public static Inventory Instance {
        get {
            if (instance == null) return null;
            return instance;
        }
    }

    public void AcquireDrink(Ingredient item) {
        float amount = item.fullAmount;
        // 주류 및 음료류의 경우 용량 1회분 추가
        // 기존 잔여량과 별개로 추가.
        AcquireIngredient(item, amount);
    }

    public void AcquireIngredient(Ingredient item, float count = 1) {
        if ((item.ingredientType == IngredientType.Liquor) || (item.ingredientType == IngredientType.NonAlcohol)) {
            for (int i = 0; i < ingredients.Count; i++) {    //add count if exist
                if ((ingredients[i] != null) && (ingredients[i].ingredientName == item.ingredientName)) {
                    if (ingredientsAmount[i] + count >= ingredients[i].fullAmount) {
                        if (ingredients.Count == maxInvenSize) {
                            //TODO 용량초과
                        }
                        float fillUp = ingredients[i].fullAmount - ingredientsAmount[i];
                        ingredientsAmount[i] = ingredients[i].fullAmount;
                        ingredients.Add(item);
                        ingredientsAmount.Add(count - fillUp);
                        // 기존갱신 및 신규추가
                    }  
                    else {
                        ingredientsAmount[i] += count;
                    // 기존갱신
                    }   // 가니시 및 기타류의 경우 기존 잔여량에 추가, 최대중첩 초과 시 따로 추가
                    
                    if (cupBoard != null) cupBoard.LoadSlot();
                    return;
                }
            }
            
        }
        // add item if not exist
        if (ingredients.Count == maxInvenSize) {
            //TODO 용량초과
        }
        ingredients.Add(item);
        ingredientsAmount.Add(count);
        // 신규추가
        if (cupBoard != null) cupBoard.LoadSlot();
    }

    public void UseIngredient(int index, int count=1) {
        //reverse
        if (ingredientsAmount[index] < count) {
            //TODO 용량부족
        }
        else {
            if (ingredientsAmount[index] == count) {
                ingredients.RemoveAt(index);
                ingredientsAmount.RemoveAt(index);
            }
            else {
                ingredientsAmount[index] -= count;
            }
        }

        if (cupBoard != null) cupBoard.LoadSlot();
    }

}
