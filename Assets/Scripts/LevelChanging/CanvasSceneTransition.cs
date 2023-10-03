using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSceneTransition : MonoBehaviour
{
    public static CanvasSceneTransition instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0) //title screen
        {
            Destroy(gameObject);
            return;
        }
    }


}
