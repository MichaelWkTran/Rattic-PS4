using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InkDialogueM : MonoBehaviour
{
    private static InkDialogueM instance;
    public static GameObject talkingToThisNPC;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TMP_Dropdown choiceDropdown;
    [SerializeField] private GameObject confirmButton;
    [SerializeField] private GameObject cancelButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private Image UIHDImage;

    public TMP_Text ratName;

    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private bool inUselessChoice = false;

    public GameObject speechSoundPrefab;
    public AudioClip speakingSound;
    private float speakingSpeed = 0.1f;
    private AudioClip[] specialSpeechList;
    private float pitchVariation = 0.2f;
    private float speechPerLetterPercent = 1.0f;
    private bool isSpecialSpeech = false;
    private string choiceText;
    private bool isShouting = false;
    private bool isSilent = false;
    public float destroySoundAfterSec = 0.5f;

    public static bool diaActive;
    private bool isTalking;
    public bool hadMini = false;
    public float diaReset = 0.001f;
    private bool disableTrade = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Error: More than one instance");
            return; //dont set instance
        }
        instance = this;
    }

    public static InkDialogueM GetInstance()
    {
        return instance;
    }

    public static void ResetInstance() { instance = null; }

    private void Start()
    {
        dialoguePanel.SetActive(false);
        diaReset = 0.1f;
    }

    private void Update()
    {
        if(!hadMini)
        {
            diaReset = 0.1f;
        }
        if(!diaActive)
        {
            return;
        }
        if (Input.GetButtonDown("Interact") && isTalking)
        {
            DisplayFullSentence();

        }
        else if (Input.GetButtonDown("Interact") && !isTalking)
        {
            //if (Input.GetButton("Action"))
            if (currentStory.currentChoices.Count == 0)
            {
                Continue();
            }
            else if(currentStory.currentChoices.Count > 0)
            {
                if(!hadMini)
                {
                    //MakeChoice();
                }
               
            }
                
        }
        if(hadMini)
        {
            diaReset -= Time.deltaTime;
            ExitDiaMode();
            if(diaReset <= 0.0f)
            {
                hadMini = false;
            }
        }
        else if(!hadMini)
        {

        }
    }

    public void EnterDialogue(TextAsset Json)
    {
        currentStory = new Story(Json.text);
        ratName.text = talkingToThisNPC.GetComponent<NPC>().ratName;
        //speakingSound.cl
        speakingSound = talkingToThisNPC.GetComponent<NPC>().speechClip;
        speakingSpeed = talkingToThisNPC.GetComponent<NPC>().speakingSpeedBetweenLetters;
        pitchVariation = talkingToThisNPC.GetComponent<NPC>().speechPitchVariation;
        speechPerLetterPercent = talkingToThisNPC.GetComponent<NPC>().percentLettersSpoken;
        UIHDImage.sprite = talkingToThisNPC.GetComponent<NPC>().HDImage;
        diaActive = true;

        if (instance == null)
        {
            instance = this;
        }


        if (!dialoguePanel)
            dialoguePanel = gameObject;
        dialoguePanel.SetActive(true);
        FindObjectOfType<MusicManager>().SwitchAudioToDialogue(talkingToThisNPC.GetComponent<NPC>().musicClip);
        FindObjectOfType<PlayerController>().canMove = false;
        Continue();


    }

    public void Continue()
    {
        if (currentStory.canContinue)
        {
           
            StopAllCoroutines();
            choiceText = currentStory.Continue();
          
            StartCoroutine(TypingSentence(choiceText));
            
            // trigger intro event if the player first talked to NPC
            if (talkingToThisNPC.GetComponent<InkDialogueTrig>().stateName == "")
            {
                talkingToThisNPC.GetComponent<NPC>().introEvent.Invoke();
            }
           
           // dialogueText.text = currentStory.Continue();
            if (dialogueText.text != "")
            {
               // if (dialogueText.text[0] == '')
               // {
               //     ExitDiaMode();
               // }
                if (dialogueText.text[0] == '!') //state change related
                {
                   
                  
                    talkingToThisNPC.GetComponent<InkDialogueTrig>().stateName = dialogueText.text.Remove(dialogueText.text.Length - 1); //set state
                    if (currentStory.canContinue) //skip past displaying the line starting with the symbol
                    {
                        
                        StopAllCoroutines();
                        choiceText = currentStory.Continue();
                        StartCoroutine(TypingSentence(choiceText));
                        //dialogueText.text = currentStory.Continue();
                    }


                    return;
                }

                if (dialogueText.text[0] == '@') //useless choice related
                {
                    inUselessChoice = !inUselessChoice;
                    if (currentStory.canContinue) //skip past displaying the line starting with the symbol
                    {
                        dialogueText.text = currentStory.Continue();
                        DisplayFullSentence();
                    }
                }

                if (dialogueText.text[0] == '>')
                {
                    if (dialogueText.text[1] == 'm') //minigame?
                    {
                        int minigameNum = (int)char.GetNumericValue(dialogueText.text[2]); //convert char to int
                        if (minigameNum == 1) //gym
                        {
                            //start the minigame
                            FindObjectOfType<TransitionPlayerScript>().TeleportToMinigame("ButtonMashingGym");
                        }
                        if (minigameNum == 2) //mystic
                        {
                            //start the minigame
                            FindObjectOfType<TransitionPlayerScript>().TeleportToMinigame("CutsceneMystic");
                        }
                        if (minigameNum == 3) //chef
                        {
                            //start the minigame
                            FindObjectOfType<TransitionPlayerScript>().TeleportToMinigame("ButtonMashingChef");
                        }
                        if (minigameNum == 4) //dog
                        {
                            //start the minigame
                            FindObjectOfType<TransitionPlayerScript>().TeleportToMinigame("ButtonMashingDog");
                        }
                        if (currentStory.canContinue) //skip past displaying the line starting with the symbol
                        {
                            dialogueText.text = currentStory.Continue();
                            DisplayFullSentence();
                        }

                    }
                    else if(dialogueText.text[1] == 'e')
                    {
                        ExitDiaMode();
                        hadMini = true;
                    }
                }
            }
            else if(dialogueText.text == ">e")
            {
                ExitDiaMode();
            }
            DisplayChoices();
        }
        else
        {
            ExitDiaMode();
        }
    }

    void LateUpdate()
    {
      if(hadMini)
        {
            ExitDiaMode();
        }

      if (disableTrade)
      {
          SetActiveTradeUI(false);
          Continue();
          disableTrade = false;
      }
    }

    IEnumerator TypingSentence(string sentence)
    {
        isTalking = true;
        dialogueText.text = sentence;



        //int visibleChar = dialogueText.textInfo.characterCount;
        int visibleChar = sentence.Length;
        


        int counter = 0;
        float speechPercentCounter = 1.0f; //default, all rats speak every letter

        while (true)
        {
            int visibleCounter = counter;

            dialogueText.maxVisibleCharacters = visibleCounter;

            if (visibleCounter >= visibleChar - 1)
            {
                break;
            }
            counter++;

            char speakingThisChar = sentence[visibleCounter];
            if (speakingThisChar == '/') //is this a command?
            {
                if (sentence[visibleCounter + 1] == 's') //is the next letter a shout command?
                {
                    isShouting = true;
                    sentence = sentence.Remove(visibleCounter, 2);
                    visibleChar = sentence.Length;
                    dialogueText.text = sentence;
                }

                else if (sentence[visibleCounter + 1] == 'q') //is the next letter a quiet/silent/whisper command?
                {
                    isSilent = true;
                    sentence = sentence.Remove(visibleCounter, 2);
                    visibleChar = sentence.Length;
                    dialogueText.text = sentence;
                }

                else if (sentence[visibleCounter + 1] == 'd') //is the next letter a return to default command?
                {
                    isShouting = false;
                    isSilent = false;
                    sentence = sentence.Remove(visibleCounter, 2);
                    visibleChar = sentence.Length;
                    dialogueText.text = sentence;
                }

                else if (sentence[visibleCounter + 1] == 't') //is the next letter a delay time command?
                {
                    int timeToWait = (int)char.GetNumericValue(sentence[visibleCounter + 2]); //convert char to int

                    yield return new WaitForSeconds(timeToWait / 10.0f); //delay speech

                    sentence = sentence.Remove(visibleCounter, 3);
                    visibleChar = sentence.Length;
                    dialogueText.text = sentence;
                }

            }
            

                speechPercentCounter += speechPerLetterPercent;
            if (speechPercentCounter >= 1.0f) //have we progressed far enough to create a sound?
            {
                if (!isSpecialSpeech && CheckIfSpeakable(speakingThisChar)) //can we speak it?
                    CreateNewSpeechSound(); //create sound
                speechPercentCounter -= 1.0f; //remove sound progress
            }


            
            yield return new WaitForSeconds(speakingSpeed);
        }
        isTalking = false;
    }
    public void DisplayFullSentence()
    {
        if (dialogueText.text == ">e")
        {
            ExitDiaMode();
        }
        StopAllCoroutines();
        ClearDialogueTextOfCommands();
        dialogueText.maxVisibleCharacters = dialogueText.text.Length;
        isTalking = false;
    }

    public void ClearDialogueTextOfCommands()
    {
        for (int i = 0; i < 10; i++)
        {
            dialogueText.text = dialogueText.text.Replace("/t" + i.ToString(), ""); //replace time for each second
        }
        dialogueText.text = dialogueText.text.Replace("/s", "");
        dialogueText.text = dialogueText.text.Replace("/q", "");
        dialogueText.text = dialogueText.text.Replace("/d", "");

        isShouting = false;
        isSilent = false;
    }

    void CreateNewSpeechSound()
    {
        GameObject newSpeakingSound = Instantiate(speechSoundPrefab);
        newSpeakingSound.GetComponent<AudioSource>().clip = speakingSound;
        newSpeakingSound.GetComponent<AudioSource>().pitch += Random.Range(-pitchVariation, pitchVariation); //randomly adjust pitch
        newSpeakingSound.GetComponent<AudioSource>().volume = GameSettings.sfxVolume;
        if (isSilent)
        {
            newSpeakingSound.GetComponent<AudioSource>().volume = 0;
        }
        newSpeakingSound.GetComponent<AudioSource>().Play();
        newSpeakingSound.GetComponent<AudioSource>().PlayOnGamepad(0);
        if (isShouting)
        {
            GameObject doubleSpeech = Instantiate(newSpeakingSound);
            Destroy(doubleSpeech, destroySoundAfterSec);
        }




        Destroy(newSpeakingSound, destroySoundAfterSec);
    }

    private bool CheckIfSpeakable(char c)
    {
        if (c == '.' || c == ' ' || c == '?' || c == '!' || c == '_' || c == '+' || c == '\'' || c == ',') 
            return false;
        return true;
    }

    private void ExitDiaMode()
    {
        
        dialogueText.text = "";
        FindObjectOfType<PlayerController>().canMove = true;
        FindObjectOfType<MusicManager>().SwitchBackToLevel();
        if(diaReset <= 0.0f)
        {
            dialoguePanel.SetActive(false);
            diaActive = false;
        }
        else if(ratName.text != "Gym Rat")
        {
            dialoguePanel.SetActive(false);
            diaActive = false;
        }
        else if (ratName.text != "Remy")
        {
            dialoguePanel.SetActive(false);
            diaActive = false;
        }
        else if (ratName.text != "Doge")
        {
            dialoguePanel.SetActive(false);
            diaActive = false;
        }
        else if (ratName.text != "Mystic")
        {
            dialoguePanel.SetActive(false);
            diaActive = false;
        }

    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > 0) //do we have a choice?
        {
            SetActiveTradeUI(true);
            if (currentChoices[0].text[0] == '!') //tries to find state intro
            {
                if (talkingToThisNPC.GetComponent<InkDialogueTrig>().stateName == "") //no state
                {
                    SetActiveTradeUI(false);
                    talkingToThisNPC.GetComponent<InkDialogueTrig>().stateName = currentChoices[0].text.Replace("\n", ""); //should be set to state intro    
                }

                //we have a state now

                //go to state
                MakeChoice(FindObjectIndex(talkingToThisNPC.GetComponent<InkDialogueTrig>().stateName, currentChoices)); //set dialogue progress to what state we are in
                return;
            }
        }
        else
        {
            SetActiveTradeUI(false);
            return;
        }

        List<string> choiceString = new List<string>();

        if (inUselessChoice)
        {
            SetActiveUselessChoiceUI(true);
            foreach (Choice choice in currentChoices) //add options according to dialogue
            {
                choiceString.Add(choice.text);
            }
        }
        else
        {
            foreach (ShareableItem item in FindObjectOfType<PlayerController>().GetComponent<Inventory>().itemInventory) //add options according to inventory
            {
                choiceString.Add(item.itemName);

            }
        }



        choiceDropdown.ClearOptions();
        choiceDropdown.AddOptions(choiceString);



        StartCoroutine(FirstChoice());
    }

    private IEnumerator FirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        Continue();
    }

    public void MakeChoice()
    {
        if (!inUselessChoice) //are we in a non useless choice (are we in one with a trade)
        {
            Inventory playerInv = FindObjectOfType<PlayerController>().GetComponent<Inventory>(); //find player
            playerInv.DoTrade(talkingToThisNPC.GetComponent<Inventory>().npcTrades, playerInv.itemInventory[choiceDropdown.value].ID); //try perform trade
        }

        //progress dialogue
        currentStory.ChooseChoiceIndex(FindObjectIndex(choiceDropdown.options[choiceDropdown.value].text, currentStory.currentChoices));
        SetActiveTradeUI(false);
        Continue();
    }

    public int FindObjectIndex(string findThis, List<Choice> currentChoices)
    {
        for (int i = 0; i < currentChoices.Count; i++) //go through the choices we have
        {
            if (currentChoices[i].text == findThis) //does this choice match the string we are looking for?
                return i;
        }


        return currentChoices.Count-1; //we didnt find any item
    }


    IEnumerator SelectChoiceDropdownAfterFrame()
    {
        yield return 0; // Wait for a frame update.
        EventSystem.current.SetSelectedGameObject(choiceDropdown.gameObject);
        choiceDropdown.OnSelect(null);
    }
    public void SetActiveTradeUI(bool shouldBeActive)
    {
        choiceDropdown.gameObject.SetActive(shouldBeActive);
        confirmButton.SetActive(shouldBeActive);
        cancelButton.SetActive(shouldBeActive);
        continueButton.SetActive(!shouldBeActive);//set this active when not trading
        if (shouldBeActive) StartCoroutine(SelectChoiceDropdownAfterFrame());
    }

    public void SetActiveUselessChoiceUI(bool shouldBeActive)
    {
        choiceDropdown.gameObject.SetActive(shouldBeActive);
        confirmButton.SetActive(shouldBeActive);
        cancelButton.SetActive(!shouldBeActive); //cannot cancel a useless choice
        continueButton.SetActive(!shouldBeActive);//set this active when not trading
        if (shouldBeActive) StartCoroutine(SelectChoiceDropdownAfterFrame());
    }

    public void CancelTrade()
    {
        disableTrade = true;
    }

}
