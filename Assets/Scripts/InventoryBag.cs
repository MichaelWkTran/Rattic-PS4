using UnityEngine;
using UnityEngine.UI;

public class InventoryBag : MonoBehaviour
{
    [SerializeField] KeyCode openInventoryKey = KeyCode.I;
    [SerializeField] Transform bag;
    [SerializeField] float itemSpriteScale = 1.5f;
    GameObject screen;
    

    void Start()
    {
        screen = transform.GetChild(0).gameObject;
        screen.SetActive(false);
        UpdateUI();
    }

    void Update()
    {
        //Can not interact with inventory if paused
        if (FindObjectOfType<PauseScreen>().isPaused)
        {
            if (screen.activeSelf) screen.SetActive(false);
            return;
        }

        //Open Close Inventory
        if (Input.GetKeyDown(openInventoryKey)) OpenClose();
    }

    public void OpenClose()
    {
        if (FindObjectOfType<PauseScreen>().isPaused) return;

        screen.SetActive(!screen.activeSelf);
        Time.timeScale = screen.activeSelf ? 0.0f : 1.0f;
    }

    public void Open()
    {
        if (FindObjectOfType<PauseScreen>().isPaused) return;

        screen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Close()
    {
        if (FindObjectOfType<PauseScreen>().isPaused) return;

            screen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void UpdateUI()
    {
        //Clear Inventory
        for (int childIndex = 0; childIndex < bag.childCount; childIndex++)
            Destroy(bag.GetChild(childIndex).gameObject);

        //Add the updated inventory
        var inventory = FindObjectOfType<PlayerController>().GetComponent<Inventory>().itemInventory;
        for (int itemIndex = 0; itemIndex < Mathf.Min(inventory.Count, 16); itemIndex++)
        {
            GameObject invSlot = new GameObject(inventory[itemIndex].itemName);
            invSlot.AddComponent<RectTransform>();
            invSlot.transform.parent = bag;

            GameObject slotSprite = new GameObject("Sprite");
            slotSprite.transform.parent = invSlot.transform;

            slotSprite.AddComponent<Image>().sprite = inventory[itemIndex].itemSprite;
            slotSprite.GetComponent<Image>().SetNativeSize();
            slotSprite.GetComponent<RectTransform>().localScale = Vector3.one * itemSpriteScale;
        }
    }
}