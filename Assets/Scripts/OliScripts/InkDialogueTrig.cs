using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InkDialogueTrig : MonoBehaviour
{
    [SerializeField] private TextAsset IJson;
    InkDialogueM activeDialogueInstance;
    private bool pInRange = false;
    public string stateName = "";
    public bool countDown = false;
    public bool canTalk = true;
    InventoryBag bag;
    Map map;
    public float diaReset = 0.1f;
    GameObject textWorld;
    public GameObject E; // E prompt
    
    public bool AnythingOpen()
    {
        return (map.isOpen || bag.isOpen);
    }

    public void Start()
    {
        textWorld = GetComponentInChildren<TMP_Text>().gameObject;
        if(GetComponent<NPC>().isNPC) { SetRandomDialog(); };
        GetComponentInChildren<TMP_Text>().text = GetComponent<NPC>().TextWorld;
        map = FindObjectOfType<Map>();
        bag = FindObjectOfType<InventoryBag>();
        textWorld.SetActive(false);
        activeDialogueInstance = InkDialogueM.GetInstance();
    }
    public void SetRandomDialog()
    {
        GetComponent<NPC>().TextWorld = FindObjectOfType<RandomNPCDialogue>().npcDialog[Random.Range(0, FindObjectOfType<RandomNPCDialogue>().npcDialog.Length)];
    }
    // Update is called once per frame
    private void Update()
    {
        if (diaReset <= 0.0f)
        {
            countDown = false;
            //activeDialogueInstance.hadMini = false;
            canTalk = true;
            activeDialogueInstance.hadMini = false;
        }

        if (!countDown)
        {
            diaReset = 0.1f;
        }

        if (countDown)
        {
            diaReset -= Time.deltaTime;
            //if(diaReset <= 0.0f)
            //{
            //    countDown = false;
            //    //activeDialogueInstance.hadMini = false;
            //    canTalk = true;
            //}
        }
        if (activeDialogueInstance.hadMini == true)
        {
            canTalk = false;
            countDown = true;
            if (activeDialogueInstance.diaReset <= 0.0f)
            {
                activeDialogueInstance.hadMini = false;
                activeDialogueInstance.diaReset = 0.0f;
            }
        }
       
        
      
        
        //If in range call the function that print the json
        if (pInRange)
        {

            //in world
            if (!InkDialogueM.diaActive)
            {
                textWorld.SetActive(true);
                if(GetComponent<NPC>().isNPC)
                {
                    E.SetActive(false);
                }
                if (Input.GetButtonDown("Interact") && !GetComponent<NPC>().isNPC && canTalk && !AnythingOpen() && !PauseScreen.isPaused)
                {
                    textWorld.SetActive(false);
                    InkDialogueM.talkingToThisNPC = gameObject;
                    //if(activeDialogueInstance.hadMini == false)
                    //{
                    activeDialogueInstance.EnterDialogue(IJson);
                    //}
                    
                }
            }
               
        }
        else
        {
            textWorld.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            pInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            pInRange = false;
        }
    }
}
