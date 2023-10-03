using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollCheck : MonoBehaviour
{
    public NavigationRoom navChecker;
    GameObject player;
    BoxCollider2D collisionChecker;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        navChecker = GetComponentInParent<NavigationRoom>();
        collisionChecker = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject == player)
        {
            navChecker.ChangeColourToWhite();
            collisionChecker.enabled = false;
        }
    }
}
