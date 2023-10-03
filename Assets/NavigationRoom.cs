using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationRoom : MonoBehaviour
{
    public SpriteRenderer[] arrows;
    public Sprite greenArrow;
    public Sprite whiteArrow;

    public void ChangeColourToGreen()
    {
        for(int i = 0; i <  arrows.Length; i++)
        {
            arrows[i].sprite = greenArrow;//color(FFFFFF;
            Debug.Log("change to green");
        }
    }

    public void ChangeColourToWhite()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].sprite = whiteArrow;//color(FFFFFF;
            Debug.Log("change to white");
        }
    }

}
