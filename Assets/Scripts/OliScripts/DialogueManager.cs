using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    public PlayerInteractionArea playerScript;


    //public TextAsset introText;
    //public TextAsset waitingText;
    //public TextAsset CompleteText;
    public TMP_Text ratName;
    public TMP_Text dialogueText;
    public bool br1 = false;
    public bool br2 = false;

    public bool first = false;

    public string dialogueTestWholeText;

    public int line = 0;

    public char removed = '|';

    private List<string> eachLine;
    private Queue<string> sentences = new Queue<string>();
    private float speakingSpeed = 0.1f;
    public bool isTalking = false;

    [SerializeField]
    private GameObject speechSoundPrefab;
    private AudioClip speakingSound;
    private AudioClip[] specialSpeechList;
    private float pitchVariation = 0.2f;
    private bool isSpecialSpeech = false;
    private int specialSpeechIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerInteractionArea>();
        gameObject.SetActive(false);
       // NPCColliding = Resources.FindObjectsOfTypeAll<PlayerInteractionArea>().NPCColliding[0];
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        playerScript = FindObjectOfType<PlayerInteractionArea>();
        playerScript.isTalking = true;
        switch (playerScript.NPCColliding.dialogueProgress)
        {
            case EDialogueProgress.Intro:
                {
                    dialogueTestWholeText = dialogue.introText.text;
                    break;
                }
            case EDialogueProgress.Waiting:
                {
                    if (br1 == true)
                    {
                        //dialogueTestWholeText = dialogue.waitingText.text;

                    }
                    else if (br2 == true &&  br1 == false)
                    {
                        //dialogueTestWholeText = dialogue.waitingText.text; dif version
                    }
                    break;
                }
            case EDialogueProgress.Complete:
                {
                    dialogueTestWholeText = dialogue.CompleteText.text;
                    break;
                }
        }
        
        speakingSpeed = dialogue.speakingSpeedBetweenLetters;
        speakingSound = dialogue.speechClip;
        pitchVariation = dialogue.speechPitchVariation;
        specialSpeechList = dialogue.specialSpeechClips;

        eachLine = new List<string>();
        eachLine.AddRange(dialogueTestWholeText.Split('|'));
        
        //for(int i = 0; i < eachLine.Count; i++)
        //{
        //    //eachLine[i] = eachLine[i].Replace(removed, ' ');
        //}
        //ratName.text = dialogue.ratName;
        
        ratName.text = playerScript.NPCColliding.dialogue.ratName.ToUpper();

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            //sentences.Enqueue(sentence);
          
        }
        for (int i = 0; i < eachLine.Count; i++)
        {
            string tempString = "";
            foreach (char letter in eachLine[i])
            {
                if(letter != '|')
                {
                    tempString += letter;
                }
                
            }
            eachLine[i] = tempString;
            sentences.Enqueue(eachLine[i]);
        }
        first = true;
        DisplayNextSentence();

    }
    public void Op1()
    {
        br1 = true; 
        br2 = false; 
    }
    public void Op2()
    {
        br2 = true;
        br1 = false;
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentenceSpoken = sentences.Dequeue();
        if (sentenceSpoken[0] == '/') //is this a special speech area?
        {
            specialSpeechIdx = (int)char.GetNumericValue(sentenceSpoken[1]); //get index
            isSpecialSpeech = true;
            CreateNewSpecialSpeechSound(); //make sound
            sentenceSpoken = sentenceSpoken.Substring(2, sentenceSpoken.Length - 2); //delete the speech starting characters
        }
        else
            isSpecialSpeech = false;

        StopAllCoroutines();
        StartCoroutine(TypingSentence(sentenceSpoken));
    }
    public void DisplayFullSentence()
    {
        StopAllCoroutines();
        dialogueText.maxVisibleCharacters = dialogueText.text.Length;
        isTalking = false;
    }

    IEnumerator TypingSentence(string sentence)
    {
        isTalking = true;
        dialogueText.text = sentence;



        //int visibleChar = dialogueText.textInfo.characterCount;
        int visibleChar = sentence.Length;
        //if(first)
        //{
        //    Debug.Log("Max Character: " + visibleChar);
        //}
        
        
        int counter = 0;
       
        if (first)
        {
           // visibleChar = 48;
        }
        while(true)
        {
            int visibleCounter = counter;


            //dialogueText.text = "";

            dialogueText.maxVisibleCharacters = visibleCounter;

            if (visibleCounter >= visibleChar-1)
            {
                break;
                //yield return new WaitForSeconds(Time.deltaTime * 60);
            }
            counter++;
            //Debug.Log("Counter: " + counter);

            if (!isSpecialSpeech)
                CreateNewSpeechSound();

            yield return new WaitForSeconds(speakingSpeed);
            //foreach (char letter in sentence.ToCharArray)
            //{
            //    dialogueText.text += letter;
            //    yield return null;
            //}
        }
        isTalking = false;
    }

    void CreateNewSpeechSound()
    {
        GameObject newSpeakingSound = Instantiate(speechSoundPrefab);
        newSpeakingSound.GetComponent<AudioSource>().clip = speakingSound;
        newSpeakingSound.GetComponent<AudioSource>().pitch += Random.Range(-pitchVariation, pitchVariation); //randomly adjust pitch
        newSpeakingSound.GetComponent<AudioSource>().Play();
#if UNITY_PS4
        newSpeakingSound.GetComponent<AudioSource>().PlayOnGamepad(0);
#endif
        //set volume here
        Destroy(newSpeakingSound, 0.2f);
    }

    void CreateNewSpecialSpeechSound()
    {
        GameObject newSpeakingSound = Instantiate(speechSoundPrefab);
        newSpeakingSound.GetComponent<AudioSource>().clip = specialSpeechList[specialSpeechIdx];
        newSpeakingSound.GetComponent<AudioSource>().Play();
#if UNITY_PS4
        newSpeakingSound.GetComponent<AudioSource>().PlayOnGamepad(0);
#endif
        //set volume here
        Destroy(newSpeakingSound, 10f);
    }

    void EndDialogue()
    {
        Debug.Log("End");
        playerScript.isTalking = false;
        gameObject.SetActive(false);
    }
}
