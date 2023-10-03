using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepThisObject : MonoBehaviour
{
    private Vector3 storedPos = Vector3.zero;
    private Quaternion storedRot;
    [SerializeField]
    private float timeAwakened;
    private int aliveChecks;

    [SerializeField]
    private string id;

    private int locatedSceneNum;

    [ContextMenu("Generate GUID for id")]
    private void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private string GetID() { return id; }
    private void WipeID() { id = "-1"; }
    private float GetTimeAwakened() { return timeAwakened; }

    private void Awake()
    {

        foreach (string s in Obituary.destroyedIDs)
        {
            if (id == s)
            {
                WipeID();
                Destroy(gameObject);
                return;
            }
        }

        DontDestroyOnLoad(this);
        timeAwakened = Time.time;
        Debug.Log(gameObject.GetInstanceID() + name + " awakened has " + GetTimeAwakened());
        locatedSceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {


    }

    public void ActivateIfRightLevel(int level)
    {
        if (level == locatedSceneNum)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0) //title screen
        {
            Destroy(gameObject);
            return;
        }

        if (id == "-1")
        {
            return;
        }
        int instanceCount = 0;
        aliveChecks += 1;
        foreach (KeepThisObject o in Resources.FindObjectsOfTypeAll<KeepThisObject>())
        {
            if (id == o.GetID())
            {
                instanceCount += 1; //count ourselves
            }
            if (id == o.GetID() && instanceCount > 1) //is there more than just us?
            {


                Debug.Log(GetTimeAwakened() + " vs " + (o.GetTimeAwakened() + 0.017f));
                Debug.Log(GetInstanceID() + " and o = " + o.GetInstanceID());
                if (GetInstanceID() == o.GetInstanceID()) //did we somehow find ourselves?
                {
                    Debug.Log("continuing and destroying with " + gameObject.GetInstanceID() + name);
                    Destroy(o.gameObject);
                    continue;

                }
                //Debug.Log(aliveChecks + " vs " + o.aliveChecks);
                if (GetTimeAwakened() < o.GetTimeAwakened()+ 0.017f)//(aliveChecks < o.aliveChecks)//
                {
                    o.WipeID();
                    //SceneManager.MoveGameObjectToScene(o.gameObject, SceneManager.GetActiveScene());
                    Debug.Log(o);

                    Destroy(o.gameObject);
                    //break;
                }
                else
                {
                    WipeID();
                    Debug.Log(gameObject);
                    Destroy(gameObject);
                    //return;
                }
            }
        }


    }

    private void OnDestroy()
    {
        if (id != "-1")
        {
            Obituary.destroyedIDs.Add(id);
        }
    }

}
