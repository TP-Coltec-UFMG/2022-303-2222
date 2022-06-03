using UnityEngine;

public class UIGenericMenu : MonoBehaviour 
{

    [Header("UI Generic Menu")]
    [SerializeField] GameObject currentSelected;
    public GameObject lastSelected {get; private set;}
    
    void Update() 
    {
        if(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == null)
        {
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(lastSelected);
        }
        UpdateLastSelected();
    }

    void UpdateLastSelected()
    {
        if(lastSelected == null)
        {
            lastSelected = UnityEngine.EventSystems.EventSystem.current.firstSelectedGameObject;
            currentSelected = UnityEngine.EventSystems.EventSystem.current.firstSelectedGameObject;
        }
        else
        {
            lastSelected = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        }
    }

    public void FirstSelected(GameObject firstButton)
    {
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(firstButton);
    }

}