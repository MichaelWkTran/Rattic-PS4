using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionPlayerScript : MonoBehaviour
{
    public static TransitionPlayerScript instance;

    private Vector3 startHerePos;
    public static string startHereString;
    public static bool startAtStartPos = false;
    private bool readyToTeleport = false;
    private bool readyToRefresh = false;

    private string beforeMinigameSceneName;
    private Vector3 beforeMinigamePos;

    private void Awake()
    {
        Debug.Log("Awakened player");
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && Input.GetKeyDown(KeyCode.Alpha0))
        {
            //debug or cheat command to teleport to dev room
            TransitionPlayerScript.startAtStartPos = true;
            TransitionPlayerScript.startHereString = "Entry";
            SceneManager.LoadScene("DevRoomScene");

        }

        if (Input.GetKey(KeyCode.Alpha1) && Input.GetKeyDown(KeyCode.Alpha9))
        {
            TeleportToMinigame("CutsceneMystic");

        }

        if (readyToTeleport)
        {
            GoThroughKeepObjects(SceneManager.GetActiveScene().buildIndex);

            readyToTeleport = false;
            //find where we are teleporting to
            startHerePos = GameObject.Find(startHereString).transform.position;

            //teleport the player transform and rb
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector3 storedVel = rb.velocity;
            rb.isKinematic = true;
            rb.MovePosition(startHerePos);
            transform.position = startHerePos;
            rb.isKinematic = false;
            rb.velocity = storedVel;

            //move camera
            FindObjectOfType<CameraController>().transform.position = new Vector3(startHerePos.x, startHerePos.y, FindObjectOfType<CameraController>().transform.position.z);
            startAtStartPos = false;
        }

        if (readyToRefresh)
        {
            Debug.Log("Refreshing in update");
            readyToRefresh = false;

            GoThroughKeepObjects(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void TeleportToMinigame(string minigameSceneName)
    {
        TransitionPlayerScript.startAtStartPos = true;
        beforeMinigamePos = transform.position;
        TransitionPlayerScript.startHereString = "Nowhere";
        GetComponent<PlayerController>().canMove = false;
        beforeMinigameSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(minigameSceneName);

    }

    public void TeleportBackFromMinigame()
    {
        TransitionPlayerScript.startAtStartPos = false;
        transform.position = beforeMinigamePos;
        readyToRefresh = true;
        SceneManager.LoadScene(beforeMinigameSceneName);

    }

    public void GoThroughKeepObjects(int level)
    {
        foreach (KeepThisObject o in Resources.FindObjectsOfTypeAll<KeepThisObject>())
        {
            o.ActivateIfRightLevel(level);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)//title screen
        {
            foreach (KeepThisObject o in Resources.FindObjectsOfTypeAll<KeepThisObject>())
            {
                Debug.Log("Deleting inactive " + o.name);
                if (!o.gameObject.activeSelf)
                    Destroy(o.gameObject);
            }
            //Destroy(FindObjectOfType<CanvasSceneTransition>().gameObject);
            Destroy(FindObjectOfType<CameraController>().gameObject);
            Destroy(gameObject);
            return;
        }

        if (startAtStartPos)
        {
            readyToTeleport = true;
        }

        readyToRefresh= true;

        //GoThroughKeepObjects(level);

    }
}
