using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptionsController : MonoBehaviour
{
    public GameObject currentObject;

    public void UpdateSubMenu(GameObject nextObject)
    {
        if(currentObject == null) 
        {
            currentObject = new GameObject();
        }
        currentObject.SetActive(false);
        nextObject.SetActive(true);
        currentObject = nextObject;
    }

    public void ExitOptions(GameObject nextObject)
    {
        nextObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
