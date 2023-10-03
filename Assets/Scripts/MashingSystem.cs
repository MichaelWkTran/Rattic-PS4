using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MashingSystem : MonoBehaviour
{
    public bool canMash = true;
    public UnityEvent mashed;

    [SerializeField] Image mashingButtonImage;
    [SerializeField] Sprite pressedSprite;
    [SerializeField] Sprite releasedprite;
    [SerializeField] Sprite cantMashSprite;

    void Start()
    {
        
    }

    void Update()
    {
        bool holdButtonInput = Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0);
        bool pressButtonInput = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

        //Add Mesh Score
        if (pressButtonInput && canMash) { mashed.Invoke(); }

        //Set Mash Sprite
        if (mashingButtonImage)
        {
            if (!canMash) mashingButtonImage.sprite = cantMashSprite;
            else if (holdButtonInput) mashingButtonImage.sprite = pressedSprite;
            else mashingButtonImage.sprite = releasedprite;
        }
    }
}
