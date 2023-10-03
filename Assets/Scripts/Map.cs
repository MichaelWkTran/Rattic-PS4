using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] KeyCode openMapKey = KeyCode.M;
    GameObject screen;

    void Start()
    {
        screen = transform.GetChild(0).gameObject;
        screen.SetActive(false);
    }

    void Update()
    {
        //Can not interact with inventory if paused
        if (FindObjectOfType<PauseScreen>().isPaused)
        {
            if (screen.activeSelf) screen.SetActive(false);
            return;
        }

        //Open Close Inventory
        if (Input.GetKeyDown(openMapKey)) OpenClose();
    }

    public void OpenClose()
    {
        if (FindObjectOfType<PauseScreen>().isPaused) return;

        screen.SetActive(!screen.activeSelf);
        Time.timeScale = screen.activeSelf ? 0.0f : 1.0f;
    }

    public void Open()
    {
        if (FindObjectOfType<PauseScreen>().isPaused) return;

        screen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Close()
    {
        if (FindObjectOfType<PauseScreen>().isPaused) return;

        screen.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
