using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject[] menus;

    public void PlayButtonSound()
    {
        RuntimeManager.PlayOneShot("event:/UI/Click");
    }

    public void OpenMenu(GameObject menu)
    {
        CloseAllMenus();
        menu.SetActive(true);
    }

    private void CloseAllMenus()
    {
        foreach (var menu in menus)
        {
            menu.SetActive(false);
        }
    }

    public void LoadScene(string scene)
    {
        Initiate.Fade(scene, Color.black, 5f);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
