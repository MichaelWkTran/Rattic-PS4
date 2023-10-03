using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemID
{
    IDNone,
    IDPaperclip,
    IDCracker,
    IDString,
    IDCheese,
    IDMushroom,
    IDShoe,
    IDThimble,
    IDMoney,
    IDPen,
    IDOrange,
    IDKey,
    IDBone,
    IDMap,
    IDBag,
    IDTape,
    IDMeal,
    IDSnack,
    IDMirror,
    IDBrokenPencil,
    IDPencil,
    IDScrapFabric,
    IDRing,
    IDPoison,
    IDStar,
    IDHat,
    IDMusicDisc,
    IDWinFamily,
    IDWinCat,
    IDWinFake
}

[CreateAssetMenu]
public class ShareableItem : ScriptableObject
{
    [SerializeField]
    private static string assetArtPath = "ItemsGlowing/";

    public string itemName;
    public Sprite itemSprite;

    public ItemID ID;

    public void init(string _itemName, string itemSpriteNameInFile, ItemID itemID)
    {
        itemName = _itemName;
        ID = itemID;

        itemSprite = Resources.Load<Sprite>(assetArtPath+ itemSpriteNameInFile);
        Debug.Log(itemSprite);
    }
}
