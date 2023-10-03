using UnityEngine;
using PathCreation;
using System.Collections.Generic;

[RequireComponent(typeof(PathObject))]
public class MovingPlatform : MonoBehaviour
{
    static public List<MovingPlatform> platformsPlayerOn = new List<MovingPlatform>();
    
    void OnTriggerEnter2D(Collider2D _collision)
    {
        //Check whether the platform is colliding with the player
        if (!_collision.transform.GetComponent<PlayerController>()) return;

        //Set the player as a child of the platform
        _collision.transform.parent = transform;
        platformsPlayerOn.Add(this);
    }

    void OnTriggerExit2D(Collider2D _collision)
    {
        //Check whether player has left the platform
        if (!_collision.transform.GetComponent<PlayerController>()) return;

        //Remove the player as a child of the platform
        platformsPlayerOn.Remove(this);
        _collision.transform.parent = (platformsPlayerOn.Count > 0) ? platformsPlayerOn[0].transform : null;
        if (_collision.transform.parent == null) DontDestroyOnLoad(_collision);
    }
}
