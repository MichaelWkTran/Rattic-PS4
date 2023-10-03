using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public bool isNewRoom;
    public Rigidbody2D rbPlayer;

    public Transform tpHerePos;

    private void Start()
    {
        if (this.GetComponent<SpriteRenderer>().enabled == true)
            this.GetComponent<SpriteRenderer>().enabled = false;

        rbPlayer = FindObjectOfType<PlayerController>().GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isNewRoom)
        {
            rbPlayer.MovePosition(tpHerePos.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (!isNewRoom)
            {
                rbPlayer.isKinematic = true;
                isNewRoom = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (isNewRoom)
            {
                rbPlayer.isKinematic = false;
                isNewRoom = false;
            }
        }
    }
}
