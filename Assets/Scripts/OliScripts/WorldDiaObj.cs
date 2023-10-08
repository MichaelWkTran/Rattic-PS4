using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WorldDiaObj : MonoBehaviour
{

    public string dialogueWorldText;
    public TMP_Text worldText;
    public GameObject empty;
    public bool isTalking = false;

    

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            worldText.text = dialogueWorldText;
            empty.SetActive(true);

            //if(Input.GetButtonDown("Interact"))
            //{
            //
            //}
        }   //
        else if(!isTalking)
        {
            worldText.text = dialogueWorldText;
            empty.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInteractionArea>())
        {
            isTalking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInteractionArea>())
        {
            isTalking = false;
        }
        
    }
}
