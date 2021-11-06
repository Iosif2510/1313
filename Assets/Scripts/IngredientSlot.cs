using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IngredientSlot : MonoBehaviour, IPointerClickHandler
{
    public CupBoard cupBoard;

    public Ingredient ingredient;
    public Image image;
    public float amountCount;

    public bool isSelected;

    [SerializeField]
    private Text textCount;

    void Awake() 
    {
        cupBoard = this.gameObject.GetComponentInParent<CupBoard>();
        image = this.gameObject.GetComponent<Image>();
        this.isSelected = false;
        image.preserveAspect = true;
        SetColor(0);
    }

    private void SetColor(float alpha) 
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }

    public void AddIngredient(Ingredient item, float count = 1) 
    {
        this.ingredient = item;
        this.amountCount = count;
        image.sprite = item.ingredientImage;

        textCount.gameObject.SetActive(true);
        textCount.text = amountCount.ToString();

        SetColor(1);
    }

    public void SetSlotCount(float count) 
    {
        amountCount += count;
        textCount.text = amountCount.ToString();

        if (amountCount <= 0) {
            ClearSlot();
        }
    }

    private void ClearSlot() 
    {
        ingredient = null;
        amountCount = 0;
        image.sprite = null;
        SetColor(0);

        textCount.text = "0";
        textCount.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        cupBoard.SelectSlot(this);
    }

}
