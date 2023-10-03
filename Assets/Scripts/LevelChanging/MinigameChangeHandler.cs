using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MinigameChangeHandler : MonoBehaviour
{
    private float gameTimer = 0.0f;
    [SerializeField]
    private float maxGameTimer = 30.0f;
    [SerializeField]
    private TMP_Text timerText;

    private int thisSceneIndex;
    // Start is called before the first frame update
    void Awake()
    {
        thisSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        if (timerText)
        {
            timerText.text = (maxGameTimer - gameTimer).ToString("F2");
        }

        if (Input.GetKey(KeyCode.Alpha1) && Input.GetKeyDown(KeyCode.Alpha8))
        {
            GoBackToWorld();

        }

        if (gameTimer >= maxGameTimer)
        {
            GoBackToWorld();
        }
    }

    public void GoBackToWorld()
    {
        FindObjectOfType<AudioSource>().GetComponent<MusicManager>().SwitchBackToLevel();
        Resources.FindObjectsOfTypeAll<TransitionPlayerScript>()[0].GetComponentInChildren<SpriteRenderer>().enabled = true;
        Resources.FindObjectsOfTypeAll<CanvasSceneTransition>()[0].gameObject.SetActive(true);
        Resources.FindObjectsOfTypeAll<TransitionPlayerScript>()[0].TeleportBackFromMinigame();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == thisSceneIndex)
        {
            Resources.FindObjectsOfTypeAll<TransitionPlayerScript>()[0].GoThroughKeepObjects(level);
            Resources.FindObjectsOfTypeAll<TransitionPlayerScript>()[0].GetComponentInChildren<SpriteRenderer>().enabled = false;
            Resources.FindObjectsOfTypeAll<CanvasSceneTransition>()[0].gameObject.SetActive(false);

        }

    }
}
