using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChangeDialog : MonoBehaviour
{
    [SerializeField] Dialogue newDialouge;
    public ItemID wantThis;
    public ItemID giveThis;
    bool dialogChanged = false;


    void Update()
    {
        if (FindObjectOfType<PlayerController>().GetComponent<Inventory>().GetFirstItemID() != ItemID.IDCracker && !dialogChanged)
        {
            GetComponent<DialogueTrigger>().dialogue = newDialouge;
            GetComponent<DialogueTrigger>().wantThis = wantThis;
            GetComponent<DialogueTrigger>().giveThis = giveThis;
            dialogChanged = true;
        }
    }
}
