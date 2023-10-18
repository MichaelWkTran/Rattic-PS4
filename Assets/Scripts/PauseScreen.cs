using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] int titleSceneIndex;
    [SerializeField] Button resumeButton;
    GameObject screen;

    public static bool isPaused { get; private set; } = false;
    public static bool canPause = true;

    void Start()
    {
        screen = transform.GetChild(0).gameObject;
        screen.SetActive(false);
    }

    void Update()
    {
        //Pause or Unpause
        if (Input.GetButtonDown("Pause") && canPause)
        {
            if (isPaused) Unpause(); else Pause();
        }
    }

    public void Pause()
    {
        if (isPaused) return;

        IEnumerator SelectButtonAfterFrame()
        {
            yield return 0; // Wait for a frame update.
            EventSystem.current.SetSelectedGameObject(resumeButton.gameObject);
            resumeButton.OnSelect(null);
        }

        screen.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        StartCoroutine(SelectButtonAfterFrame());
    }

    public void Unpause()
    {
        if (!isPaused) return;

        screen.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(titleSceneIndex);
    }
}
