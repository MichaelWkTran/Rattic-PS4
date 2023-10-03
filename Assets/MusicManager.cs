using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource lvlMusicSource;
    public AudioSource dialogueMusicSource;
    [SerializeField, Range(0.0f, 1.0f)] float volumeTransitionRate = 1.0f;
    bool isDialogMusic = false; //If true, then the dialog music is playing, otherwise the level music is playing

    void Update()
    {
        //Checks whether the transition has finished
        if (!isDialogMusic)
        {
            //If the transition from dialog to level has finished, stop the dialog music
            if (lvlMusicSource.volume == GameSettings.musicVolume)
            {
                dialogueMusicSource.Stop();
                return;
            }
        }
        else
        {
            if (lvlMusicSource.volume == 0.0f) { return; }
        }

        //Crossfade between lvlMusicSource and dialogueMusicSource
        lvlMusicSource.volume += volumeTransitionRate * (!isDialogMusic ? 1.0f : -1.0f) * Time.deltaTime;
        lvlMusicSource.volume = Mathf.Clamp(lvlMusicSource.volume, 0, GameSettings.musicVolume);
        dialogueMusicSource.volume = GameSettings.musicVolume - lvlMusicSource.volume;
    }

    public void SwitchAudioToDialogue(AudioClip ratType)
    {
        if (ratType == null || isDialogMusic) return;

        isDialogMusic = true;
        dialogueMusicSource.clip = ratType;
        dialogueMusicSource.Play();
    }

    public void SwitchBackToLevel()
    {
        if (!isDialogMusic) return;

        isDialogMusic = false;
    }
}
