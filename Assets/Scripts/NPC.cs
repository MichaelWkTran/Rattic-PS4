using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public string ratName;

    [TextArea(3, 10)]
    public string[] sentences;
    public bool isNPC = false;

    public UnityEvent introEvent;

    public string TextWorld;

    public AudioClip speechClip;
    public float speechPitchVariation = 0.2f;
    public AudioClip[] specialSpeechClips;

    public AudioClip musicClip;

    public float speakingSpeedBetweenLetters = 0.4f;
    public float percentLettersSpoken = 1.0f;

    public Sprite HDImage = null;
}