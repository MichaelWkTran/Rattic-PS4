using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] int gameSceneIndex;

    public void PlayGame()
    {
        //reset variables as if we played from last time
        Obituary.destroyedIDs.Clear();
        TransitionPlayerScript.instance = null;
        TransitionPlayerScript.startAtStartPos = false;
        TransitionPlayerScript.startHereString = "";

        CanvasSceneTransition.instance = null;

        InkDialogueM.ResetInstance();
        InkDialogueM.talkingToThisNPC = null;
        InkDialogueM.diaActive = false;

        PlayerInteractionArea.ClearResetInventory();

        Time.timeScale = 1.0f;

        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
