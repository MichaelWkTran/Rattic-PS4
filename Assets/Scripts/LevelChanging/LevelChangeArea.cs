using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeArea : MonoBehaviour
{
    public string teleportHereObjName;
    public string loadThisSceneString;
    public int loadThisSceneNum;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        TransitionPlayerScript transition = collision.GetComponent<TransitionPlayerScript>();
        if (!transition)
            transition = collision.GetComponentInParent<TransitionPlayerScript>();
        Debug.Log(transition);
        if (transition)
        {
            Debug.Log("teleporting");
            TransitionPlayerScript.startAtStartPos = true;
            Debug.Log(TransitionPlayerScript.startAtStartPos);
            TransitionPlayerScript.startHereString = teleportHereObjName;

            if (loadThisSceneString != "")
                SceneManager.LoadScene(loadThisSceneString);
            else
                SceneManager.LoadScene(loadThisSceneNum);

        }
    }
}
