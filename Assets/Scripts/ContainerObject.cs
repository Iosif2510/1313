using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContainerObject : MonoBehaviour, IPointerClickHandler
{
    public BarServeManager barServeManager;
    public Container currentContainer;
    private Image containerImage;

    public List<(Ingredient item, int amount)> containerList = new List<(Ingredient item, int amount)>();
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
    }

    public int Pour(Ingredient ingredient, int amount) 
    {
        //* 부은 진짜 양을 리턴
        //* 가니시의 용량은 0으로 취급
        if (currentAmount + amount > fullAmount) 
        {
            containerList.Add((ingredient, fullAmount - currentAmount));
            return (fullAmount - currentAmount);
        }
        else 
        {
            containerList.Add((ingredient, amount));
            return amount;
        }
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        Debug.Log("Container Click");
        barServeManager.Pour();
        PrintContainer();
    }

    void CheckRecipe() {
        
    }

    public void PrintContainer() 
    {
        foreach (var pouredIngredients in containerList) 
        {
            Debug.Log($"{pouredIngredients.item} {pouredIngredients.amount}ml");
        }
    }
}
