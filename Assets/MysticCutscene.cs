using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_PS4
using UnityEngine.PS4;
#endif

public class MysticCutscene : MonoBehaviour
{
    [SerializeField] float lightHueChangeRate;
    float lightHue = 0.0f;

    void Update()
    {
#if UNITY_PS4
    if (PS4Input.PadIsConnected(0))
    {
        lightHue = Mathf.Repeat(lightHue += Time.deltaTime * lightHueChangeRate, 1.0f);
        Color newColor = Color.HSVToRGB(lightHue, 1.0f, 1.0f);        
    
        //Change Gamepad Light Colour
         PS4Input.PadSetLightBar(0, (int)(newColor.r * 255), (int)(newColor.g * 255), (int)(newColor.b * 255));
    }

#endif
    }

    void OnDestroy()
    {

    }
}
