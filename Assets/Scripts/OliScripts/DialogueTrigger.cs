using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum EDialogueProgress
{
    Intro,
    Waiting,
    Complete
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField]
    public PlayerInteractionArea playerScript;

    public EDialogueProgress dialogueProgress = EDialogueProgress.Intro;
    public ItemID wantThis;
    public ItemID giveThis;
    public List<Trade> availableTrades;
    public bool inConversation = false;
    public bool isMidTalking = false;
    private DialogueManager dm;

    public MusicManager musicScript;
    public AudioClip ratMusicClip;

    public TMP_Text worldText;
    public string dialogueWorldText;

    private void Start()
    {
        dm = Resources.FindObjectsOfTypeAll<DialogueManager>()[0];
        playerScript = FindObjectOfType<PlayerInteractionArea>();
        musicScript = FindObjectOfType<MusicManager>();

    }

    private void Update()
    {
        if (dm)
        {
            inConversation = dm.gameObject.activeSelf;
            if (dm.isTalking)
            {
                isMidTalking = true;
            }
            else
            {
                isMidTalking = false;
            }
        }
        else
        {
            
            worldText.gameObject.SetActive(false);
        }
    }

    public void TriggerDialogue()
    {
        if (dm)
        {
            dm.gameObject.SetActive(true);
            dm.StartDialogue(dialogue);
            worldText.gameObject.SetActive(false);
            musicScript.SwitchAudioToDialogue(ratMusicClip);
        }
    }
    public void WorldPopupDialogue()
    {
        if (playerScript.NPCColliding)
        {
            switch (playerScript.NPCColliding.dialogueProgress)
            {
                case EDialogueProgress.Intro:
                    {
                        dialogueWorldText = dialogue.introTextWorld.text;
                        break;
                    }
                case EDialogueProgress.Waiting:
                    {
                        dialogueWorldText = dialogue.waitingTextWorld.text;
                        break;
                    }
                case EDialogueProgress.Complete:
                    {
                        dialogueWorldText = dialogue.CompleteTextWorld.text;
                        break;
                    }
            }
            worldText.text = dialogueWorldText;
            worldText.gameObject.SetActive(true);
            musicScript.SwitchBackToLevel();
            //dm.gameObject.SetActive(true);
        }
    }

    public void NextSentence()
    {
        if (dm && inConversation)
        {
            dm.DisplayNextSentence();
        }
    }
    public void FinSentence()
    {
        if (dm && isMidTalking)
        {
            dm.DisplayFullSentence();
        }
    }
}
