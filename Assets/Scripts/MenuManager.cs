using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    [SerializeField] private GameObject mainMenuGroup = null;
    [SerializeField] private GameObject optionsMenuGroup = null;
    [SerializeField] private GameObject soundMenuGroup = null;
    [SerializeField] private GameObject keyBindingsMenuGroup = null;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CloseMenuGroups() {
        mainMenuGroup.SetActive(false);
        optionsMenuGroup.SetActive(false);
        soundMenuGroup.SetActive(false);
        keyBindingsMenuGroup.SetActive(false);
    }

    public void OpenMainMenu() {
        CloseMenuGroups();
        mainMenuGroup.SetActive(true);
    }

    public void OpenOptionsMenu() {
        CloseMenuGroups();
        optionsMenuGroup.SetActive(true);
    }

    public void OpenSoundMenu() {
        CloseMenuGroups();
        soundMenuGroup.SetActive(true);
    }

    public void OpenKeyBindingsMenu() {
        CloseMenuGroups();
        keyBindingsMenuGroup.SetActive(true);
    }
}
