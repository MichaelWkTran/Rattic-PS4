using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Trade 
{
    public List<ItemID> wantThese;
    public List<ShareableItem> giveThese;
    public List<Trade> unlockTheseTrades;
    public UnityEvent trandeEvent;

    public Trade(ItemID[] _wantThese, ShareableItem[] _giveThese)
    {
        giveThese = new List<ShareableItem>();
        foreach (ShareableItem i in giveThese)
        {
            giveThese.Add(i);
        }

        wantThese = new List<ItemID>();
        foreach (ItemID i in _wantThese)
        {
            wantThese.Add(i);
        }
    }

    public Trade(ItemID[] _wantThese, ShareableItem _giveThis)
    {
        giveThese = new List<ShareableItem>();
        giveThese.Add(_giveThis);

        wantThese = new List<ItemID>();
        foreach (ItemID i in _wantThese)
        {
            wantThese.Add(i);
        }

    }

    public Trade(ItemID _wantThis, ShareableItem _giveThis)
    {
        giveThese = new List<ShareableItem>();
        giveThese.Add(_giveThis);

        wantThese = new List<ItemID>();
        wantThese.Add(_wantThis);

    }


}

public class Inventory : MonoBehaviour
{
    public List<ShareableItem> itemInventory = new List<ShareableItem>();
    [SerializeField]
    private GameObject shareWithThisRat;
    [SerializeField]
    private bool canTrade;

    private bool isPlayer;
    [SerializeField]
    private Image UISprite;
    [SerializeField]
    private TMP_Text UIText;
    [SerializeField] private bool dontDeleteTrade = false;
    private bool hasWon = false;
    private bool hasDisplayedPath = false;
    private bool hasDisplayedWinImage = false;
    private int winType = -1;

    public List<Trade> npcTrades = new List<Trade>();


    // Start is called before the first frame update
    void Start()
    {
        isPlayer = GetComponent<PlayerController>();
        RefreshInventoryUI();
        //ShareableItem coolItem = ScriptableObject.CreateInstance("ShareableItem") as ShareableItem; coolItem.init("Cheese", "Cheese", ItemID.IDCheese);
        //Trade t = new Trade(new ItemID[] { ItemID.IDString, ItemID.IDShoe }, coolItem);
        //npcTrades.Add(t);
        //("Cheese", "Cheese.png", ItemID.IDCheese)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < npcTrades.Count; i++)
            {
                ///Debug.Log(gameObject.name + " wants a " + npcTrades[0].wantThese[0]);
            }
            for (int i = 0; i < npcTrades.Count; i++)
            {
                ///Debug.Log(gameObject.name + " gives a " + npcTrades[0].giveThese[0].itemName);
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && canTrade)
        {
            //DoTrade(shareWithThisRat.GetComponent<Inventory>(), ItemID.IDPaperclip, ItemID.IDCracker);

        }

        if (hasWon)
        {
            if (!InkDialogueM.diaActive)
            {
                if (!hasDisplayedPath)
                {
                    FindObjectOfType<PlayerController>().transform.position = FindObjectOfType<PlayerController>().transform.position + new Vector3(0, 0, -1.0f); //move player in Z position so colliders stop working, so we dont talk to NPCs
                    FindObjectOfType<PlayerController>().canMove = false; //stop movement
                    FindObjectOfType<PlayerController>().GetComponent<Collider2D>().enabled = false;
                    FindObjectOfType<PlayerController>().GetComponentInChildren<Collider2D>().enabled = false;

                    hasDisplayedPath = true;
                    FindObjectOfType<WinScreen>().Win();
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!hasDisplayedWinImage)
                    {
                        hasDisplayedWinImage = true;
                        FindObjectOfType<WinScreen>().EndCutscene(winType);
                    }
                    else
                    {
                        FindObjectOfType<TransitionPlayerScript>().ReturnToTitle();
                    }
                }

            }
        }
    }

    public void RefreshInventoryUI()
    {
        if (!isPlayer) //dont change UI for NPCs as they dont have UI
            return;
        if (itemInventory.Count > 0)
        {
            UISprite.sprite = itemInventory[0].itemSprite;
            UIText.text = itemInventory[0].itemName;
        }
        else
        {
            UISprite.sprite = null;
            UIText.text = "Nothing";
        }
    }

    /// <summary>
    /// old trade code
    /// </summary>
    /// <param name="otherInventory"></param>
    /// <param name="giveID"></param>
    /// <param name="takeID"></param>
    /// <returns></returns>
    public bool DoTrade(Inventory otherInventory, ItemID giveID, ItemID takeID)
    {
        int giveIndex = -1;
        int takeIndex = -1;
        for (int i = 0; i < itemInventory.Count; i++)
        {
            if (itemInventory[i].ID == giveID)
            {
                giveIndex = i;
                break;
            }
        }

        for (int i = 0; i < otherInventory.itemInventory.Count; i++)
        {
            if (otherInventory.itemInventory[i].ID == takeID)
            {
                takeIndex = i;
                break;
            }
        }

        if (giveIndex == -1 || takeIndex == -1)
        {
            return false;
        }

        Debug.Log("Share complete");

        //add Item to win screen
        FindObjectOfType<WinScreen>().AddItem(otherInventory.itemInventory[takeIndex].itemSprite);

        //take item from other inventory
        itemInventory.Add(otherInventory.itemInventory[takeIndex]);
        otherInventory.itemInventory.RemoveAt(takeIndex);

        //give item to other inventory
        otherInventory.itemInventory.Add(itemInventory[giveIndex]);
        itemInventory.RemoveAt(giveIndex);

        RefreshInventoryUI();
        StartCoroutine(TradeColor(otherInventory));
        return true;
    }

    public bool DoTrade(List<Trade> NPCTrades, ItemID offerID)
    {
        int giveIndex = -1;
        int wantIndex = -1;
        int tradeIndex = -1;
        //does the player have the item?
        for (int i = 0; i < itemInventory.Count; i++)
        {
            if (itemInventory[i].ID == offerID)
            {
                giveIndex = i;
                break;
            }
        }

        if (giveIndex == -1)
        {
            return false;
        }

        //is there a trade which the npc wants this item?
        for (int i = 0; i < NPCTrades.Count; i++)
        {
            //does the NPC want the item for this trade??
            for (int j = 0; j < NPCTrades[i].wantThese.Count; j++)
            {
                if (NPCTrades[i].wantThese[j] == offerID)
                {
                    wantIndex = j;
                    tradeIndex = i;
                    break;
                }
            }
        }

        if (tradeIndex == -1)
            return false;

        if (wantIndex == -1)
            return false;



        Debug.Log("Share complete");

        //player recieves items
        for (int i = 0; i < NPCTrades[tradeIndex].giveThese.Count; i++)
        {
            itemInventory.Add(NPCTrades[tradeIndex].giveThese[i]);

            //Add items to win screen
            FindObjectOfType<WinScreen>().AddItem(NPCTrades[tradeIndex].giveThese[i].itemSprite);

            //Activate win screen depending on the traded item
            switch (NPCTrades[tradeIndex].giveThese[i].ID)
            {
                case ItemID.IDWinCat:
                    winType = 1;
                    hasWon = true;
                    break;
                case ItemID.IDWinFake:
                    winType = 2;
                    hasWon = true;
                    break;
                case ItemID.IDWinFamily:
                    winType = 0;
                    hasWon = true;
                    break;
            }
        }
        //NPC gets new trade if possible
        if (NPCTrades[tradeIndex].unlockTheseTrades.Count>0)
            NPCTrades.Add(NPCTrades[tradeIndex].unlockTheseTrades[0]);

        //execute trade event
        NPCTrades[tradeIndex].trandeEvent.Invoke();

        //remove the trade from the NPC
        if (!dontDeleteTrade)
            NPCTrades.RemoveAt(tradeIndex);

        //player loses offered item
        itemInventory.RemoveAt(giveIndex);

        RefreshInventoryUI();
        FindObjectOfType<InventoryBag>().UpdateUI();
        //StartCoroutine(TradeColor(otherInventory));

        return true;
    }

    public ItemID GetFirstItemID()
    {
        if (itemInventory.Count > 0)
            return itemInventory[0].ID;
        return ItemID.IDNone;
    }

    public void CollectItem(ShareableItem theItem)
    {
        itemInventory.Add(theItem);
    }
    IEnumerator TradeColor(Inventory otherInventory)
    {
        if (isPlayer)
        {
            otherInventory.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            this.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;

        }
        //yield return new WaitForSeconds(0.5f);
        if (isPlayer)
        {
            float ColorChangeProgress = 0f;
            while (ColorChangeProgress < 1.0f)
            {
                ColorChangeProgress += Time.deltaTime * 0.9f;
                otherInventory.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.yellow, Color.white, ColorChangeProgress);
                this.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.yellow, Color.white, ColorChangeProgress);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }
}
