using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] int titleSceneIndex;
    GameObject screen;

    public bool isPaused { get; private set; } = false;

    void Start()
    {
        screen = transform.GetChild(0).gameObject;
        screen.SetActive(false);
    }

    void Update()
    {
        //Pause or Unpause
        if (Input.GetKeyDown(pauseKey))
        {
            if (isPaused) Unpause(); else Pause();
        }
    }

    public void Pause()
    {
        if (isPaused) return;

        screen.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
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
