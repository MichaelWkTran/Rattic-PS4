using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{
    public AudioClip mysticMini;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioSource>().GetComponent<MusicManager>().SwitchBackToLevel();
        FindObjectOfType<AudioSource>().GetComponent<MusicManager>().SwitchAudioToDialogue(mysticMini);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
