using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string ratName;

    [TextArea(3, 10)]
    public string[] sentences;

    public TextAsset introText;
    //public TextAsset waitingText;
    public TextAsset CompleteText;

    public TextAsset introTextWorld;
    public TextAsset waitingTextWorld;
    public TextAsset CompleteTextWorld;

    public AudioClip speechClip;
    public float speechPitchVariation = 0.2f;
    public AudioClip[] specialSpeechClips;

    public float speakingSpeedBetweenLetters = 0.4f;

}
