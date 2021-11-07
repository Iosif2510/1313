using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarServeManager : MonoBehaviour
{
    public Inventory inventory;
    // Bar Serve 씬에서만 존재
    public ContainerObject container;

    public Text selectedAmountText;

    public IngredientSlot selectedSlot;
    public int selectedIndex = -1;

    public float selectedPourAmount;


    // Start is called before the first frame update
    void Awake()
    {
        inventory = Inventory.Instance;
    }

    // Update is called once per frame
    void Start()
    {
        // selectedAmountText.text = "Pour Amount: " + selectedPourAmount.ToString();
    }

    public void SelectSlot(IngredientSlot slot, int index)
    {
        selectedSlot = slot;
        selectedIndex = index;
        selectedPourAmount = 0;
    }

    public void UnSelectSlot()
    {
        selectedSlot = null;
        selectedIndex = -1;
        selectedPourAmount = 0;
    }

    void SelectAmount(float amount)
    {
        if ((selectedSlot != null) && (selectedSlot.amountCount >= amount))
        {
            this.selectedPourAmount = amount;
        }
    }

    public void Select1Oz()
    {
        SelectAmount(30);
    }

    public void SelectHalfOz()
    {
        SelectAmount(15);
    }

    public void SelectThirdOz()
    {
        SelectAmount(10);
    }

    public void SelectQuarterOz()
    {
        SelectAmount(7.5f);
    }

    public void SelectDash()
    {
        SelectAmount(1);
    }

    public void Pour()
    {
        if ((selectedSlot != null) && (selectedPourAmount != 0))
        {
            if (inventory.ingredientsAmount[selectedIndex] < selectedPourAmount)
            {
                //TODO 남은 아이템 양 부족
                return;
            }
            float actualPour = container.Pour(selectedSlot.ingredient, selectedPourAmount);

            if (actualPour >= 0)
            {
                inventory.UseIngredient(selectedIndex, actualPour);
            }
            else
            {
                //TODO 컨테이너 용량 부족 애니메이션
            }
        }
    }

}
