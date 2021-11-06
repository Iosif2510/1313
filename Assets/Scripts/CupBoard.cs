using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoard : MonoBehaviour
{
    public static bool inventoryActivated = false;

    public List<Ingredient> cupBoard;
    public List<float> cupBoardAmount;

    [SerializeField]
    private BarServeManager barServeManager;
    [SerializeField]
    private GameObject inventoryBase;
    [SerializeField]
    private GameObject slotsParent;

    private IngredientSlot[] slots;
    private int pageSize;

    public int currentPage;

    void Start()
    {
        cupBoard = Inventory.Instance.ingredients;
        cupBoardAmount = Inventory.Instance.ingredientsAmount;
        slots = slotsParent.GetComponentsInChildren<IngredientSlot>();
        pageSize = 8;

        LoadSlot(); // Slot의 초기화를 우선하기 위해 Start에 set
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OpenInventory() {
        //TODO open animation
        inventoryBase.SetActive(true);
    }

    private void CloseInventory() {
        //TODO close animation
        inventoryBase.SetActive(false);
    }

    // cupBoard index = cupBoardAmount index = slots index
    public void LoadSlot(int page = 0) {
        for (int i = page * pageSize; i < (page + 1) * pageSize; i++) {
            if (i >= cupBoard.Count) {
                slots[i].gameObject.SetActive(false);
            }
            // Debug.Log(cupBoard[i].ingredientName);
            else {
                slots[i].gameObject.SetActive(true);
                slots[i].AddIngredient(cupBoard[i], cupBoardAmount[i]);
            }
            
        }
        //TODO 슬라이드 구현
    }

    public void SelectSlot(IngredientSlot slot) {
        int slotIndex = -1;
        if (!slot.isSelected) {
            for (int i = 0; i < slots.Length; i++) {
                slots[i].isSelected = false;
                if (slots[i] == slot) slotIndex = i;
            }
            slot.isSelected = true;
            barServeManager.SelectSlot(slot, slotIndex);
        }
        else {
            slot.isSelected = false;
            barServeManager.UnSelectSlot();
        }
    }

}
