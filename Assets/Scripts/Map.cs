using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    GameObject screen;
    public bool isOpen => screen.activeSelf;
    void Start()
    {
        screen = transform.GetChild(0).gameObject;
        screen.SetActive(false);
    }

    void Update()
    {
        //Can not interact with inventory if paused
        if (PauseScreen.isPaused)
        {
            if (screen.activeSelf) screen.SetActive(false);
            return;
        }

        //Open Close Inventory
        if (Input.GetButtonDown("Map")) OpenClose();
    }

    public void OpenClose()
    {
        if (PauseScreen.isPaused) return;
        screen.SetActive(!screen.activeSelf);
        Time.timeScale = screen.activeSelf ? 0.0f : 1.0f;
    }

    public void Open()
    {
        if (PauseScreen.isPaused) return;
        PauseScreen.canPause = false;
        screen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Close()
    {
        if (PauseScreen.isPaused) return;
        PauseScreen.canPause = true;
        screen.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
