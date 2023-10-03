using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionArea : MonoBehaviour
{
    [SerializeField]
    private Inventory playerInventory;
    private bool pickingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GetComponentInParent<Inventory>();
        if (Input.GetKeyDown(KeyCode.E))
        {
            pickingUp = true;

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.GetComponent<WorldItem>() && pickingUp)
        {
            pickingUp = false;
            playerInventory.CollectItem(other.GetComponent<WorldItem>().item);
            Destroy(other.gameObject);
        }
    
    }
}
