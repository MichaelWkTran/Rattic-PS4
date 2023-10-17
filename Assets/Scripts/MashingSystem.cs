using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
#if UNITY_PS4
using UnityEngine.PS4;
#endif

public class MashingSystem : MonoBehaviour
{
    public bool canMash = true;
#if UNITY_PS4
    [SerializeField] Vector3 lastGyro;
    float minShakeDistance = 2;
#endif
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
        bool holdButtonInput = Input.GetButton("Interact") || Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0);
        bool pressButtonInput = Input.GetButtonDown("Interact") || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);


#if UNITY_PS4
    if (PS4Input.PadIsConnected(0))
    {
        Vector3 currentGyro = PS4Input.PadGetLastGyro(0);
        if ((currentGyro - lastGyro).sqrMagnitude > minShakeDistance * minShakeDistance) pressButtonInput = true;
        
        lastGyro = currentGyro;
    }

#endif

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
