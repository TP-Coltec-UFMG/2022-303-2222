using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptionsController : UIGenericMenu
{
    [Header("UI Options Menu")]
    [SerializeField] GameObject currentObject;
    private void Start() {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
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
    public void OnVolumeValueChange() {
        float soundVolume = GameObject.Find("Slider").GetComponent<Slider>().value;
        AudioListener.volume = soundVolume;
        PlayerPrefs.SetFloat("volume", soundVolume);
    }
}
