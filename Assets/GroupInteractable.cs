using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GroupInteractable : MonoBehaviour
{
    //void OnLevelWasLoaded()
    //{
    //    GetComponent<CanvasGroup>().interactable = gameObject.activeInHierarchy;
    //}
    //void Start()
    //{
    //    //GetComponent<CanvasGroup>().interactable = gameObject.activeInHierarchy;
    //}
    
    void OnEnable()
    {
        GetComponent<CanvasGroup>().interactable = true;
    }
    
    void OnDisable()
    {
        GetComponent<CanvasGroup>().interactable = false;
    }
}
