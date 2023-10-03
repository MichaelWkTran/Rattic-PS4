using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static Transform followThis;
    public static CameraController instance;
    public static float followSpeed = 20.0f;

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

    // Start is called before the first frame update
    void Start()
    {
        followThis = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(followThis.position.x, followThis.transform.position.y, transform.position.z), followSpeed * Time.deltaTime);
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
