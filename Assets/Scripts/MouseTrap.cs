using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    [SerializeField] bool ignorePlatforms = false;
    bool collidingWithPlayer = false;
    [SerializeField] private GameObject soundPrefab;
    [SerializeField] private AudioClip impactWithPlayerSound;
    private float impactSoundCooldown = 0.0f;

    void Update()
    {
        impactSoundCooldown -= Time.deltaTime; //so we dont play like 15 sounds at once, blasting the ears of our users

        //Check whether the player is colliding with the trap
        if (!collidingWithPlayer) return;

        //Check whether the player is not on a moving object
        if (!ignorePlatforms && MovingPlatform.platformsPlayerOn.Count > 0) return;


        if (impactWithPlayerSound && impactSoundCooldown <= 0) //create an impact sound if we have one
        {
            impactSoundCooldown = 0.1f;
            GameObject hitSound = Instantiate(soundPrefab);
            hitSound.GetComponent<AudioSource>().clip = impactWithPlayerSound;
            hitSound.GetComponent<AudioSource>().Play();
            hitSound.GetComponent<AudioSource>().volume = GameSettings.sfxVolume;
            Destroy(hitSound, 4.0f);
        }

        //Warp player to checkpoint
        Checkpoint.SpawnAtCheckpoint();
    }

    void OnTriggerEnter2D(Collider2D _collision)
    {
        //Check whether the trap is colliding with the player
        if (!_collision.transform.GetComponent<PlayerController>()) return;

        collidingWithPlayer = true;
    }

    void OnTriggerExit2D(Collider2D _collision)
    {
        //Check whether the leaving collider is the player
        if (!_collision.transform.GetComponent<PlayerController>()) return;

        collidingWithPlayer = false;
    }
}
