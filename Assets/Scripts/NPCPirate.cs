using UnityEngine;

public class NPCPirate : MonoBehaviour
{
    GameObject map;

    void Start()
    {
        map = FindObjectOfType<Map>().gameObject;
    }

    //An event called when the player first talks to the pirate.
    //The pirate will steal the player's map and the player is unable to use it. 
    public void StealMap()
    {
        map.SetActive(false);
    }

    //An event called when trading the pirate with money. The pirate will return the map
    public void ReturnMap()
    {
        map.SetActive(true);
    }
}