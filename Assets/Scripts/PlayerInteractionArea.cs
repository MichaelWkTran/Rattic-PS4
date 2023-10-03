using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionArea : MonoBehaviour
{
    [SerializeField]
    public DialogueTrigger NPCColliding;
    public WorldItem OBJColliding = null;
    private static Inventory playerInventory;
    public bool isTalking = false;

    public GameObject speechSoundPrefab;
    public AudioClip speakingSound;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GetComponentInParent<Inventory>();
    }

    public static void ClearResetInventory()
    {
        if (playerInventory)
            playerInventory.itemInventory.Clear();
        playerInventory = null;
    }

    // Update is called once per frame
    void Update()
    {

        //are we picking up an object?
        if(OBJColliding && Input.GetKeyDown(KeyCode.E))
        {
            playerInventory.itemInventory.Add(OBJColliding.GetComponent<WorldItem>().item);
            FindObjectOfType<InventoryBag>().UpdateUI();
            GameObject newSpeakingSound = Instantiate(speechSoundPrefab);
            newSpeakingSound.GetComponent<AudioSource>().clip = speakingSound;
            newSpeakingSound.GetComponent<AudioSource>().Play();
            newSpeakingSound.GetComponent<AudioSource>().volume = GameSettings.sfxVolume;
            Destroy(newSpeakingSound, 0.5f);
            Destroy(OBJColliding.gameObject);
        }
        if (NPCColliding && !(Input.GetKeyDown(KeyCode.E)))
        {
            if (!NPCColliding.inConversation)
            {
                switch (NPCColliding.dialogueProgress)
                {
                    case EDialogueProgress.Intro:
                        {
                            NPCColliding.WorldPopupDialogue();
                            break;
                        }
                    case EDialogueProgress.Waiting:
                        {
                            NPCColliding.WorldPopupDialogue();
                            break;
                        }
                    case EDialogueProgress.Complete:
                        {
                            NPCColliding.WorldPopupDialogue();
                            break;
                        }
                }
            }
        }
        if (NPCColliding && Input.GetKeyDown(KeyCode.E))
        {
            if (!NPCColliding.inConversation)
            {
                switch (NPCColliding.dialogueProgress)
                {
                    case EDialogueProgress.Intro:
                        {
                            NPCColliding.TriggerDialogue();
                            FindObjectOfType<TaskLog>().AddItem(NPCColliding.name, "Find " + NPCColliding.wantThis.ToString() + " for " + NPCColliding.name);
                            NPCColliding.dialogueProgress = EDialogueProgress.Waiting;
                            //isTalking = true;
                            break;
                        }
                    case EDialogueProgress.Waiting:
                        {
                            if (!playerInventory.DoTrade(NPCColliding.GetComponent<Inventory>().npcTrades, playerInventory.itemInventory[0].ID))
                            {
                                Debug.Log("TRADE INCOMPLETE!!!");
                                NPCColliding.dialogueProgress = EDialogueProgress.Intro;
                                NPCColliding.TriggerDialogue();
                                NPCColliding.dialogueProgress = EDialogueProgress.Waiting;
                                //isTalking = true;
                            }
                            else
                            {
                                NPCColliding.dialogueProgress = EDialogueProgress.Complete;
                                NPCColliding.TriggerDialogue();
                                FindObjectOfType<TaskLog>().RemoveItem(NPCColliding.name);
                                //isTalking = true;
                            }

                            break;
                        }
                    case EDialogueProgress.Complete:
                        {
                            NPCColliding.TriggerDialogue();
                            break;
                        }
                }
            }
            else //npc is in conversation, progress it
            {
                if (NPCColliding.isMidTalking)
                {
                    NPCColliding.FinSentence();
                    //isTalking = false;
                }
                else
                {
                    NPCColliding.NextSentence();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DialogueTrigger>())
        {
            NPCColliding = other.GetComponent<DialogueTrigger>();
            
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DialogueTrigger>())
        {
            NPCColliding.worldText.gameObject.SetActive(false);
            NPCColliding = null;
            
        }
        OBJColliding = null;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<WorldItem>())
        {
            OBJColliding = other.GetComponent<WorldItem>();
        }


    }
}
