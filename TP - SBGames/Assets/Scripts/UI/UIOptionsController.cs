using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptionsController : UIGenericMenu
{
    [Header("UI Options Menu")]
    [SerializeField] GameObject currentObject;
    
    public void UpdateSubMenu(GameObject nextObject)
    {
        if(currentObject == null) 
        {
            currentObject = new GameObject();
            Destroy(currentObject, 5f);
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
