using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    static Checkpoint currentSpawn;
    [SerializeField] Transform spawn;
    
    public static void SpawnAtCheckpoint()
    {
        //Move the player to the checkpoint spawn location
        FindObjectOfType<PlayerController>().transform.position = currentSpawn.spawn.position;
    }

    void OnTriggerEnter2D(Collider2D _collision)
    {
        //Check whether the checkpoint is colliding with the player
        if (!_collision.transform.GetComponent<PlayerController>()) return;

        //Set the player to spawn at this checkpoint
        currentSpawn = this;
    }
}
