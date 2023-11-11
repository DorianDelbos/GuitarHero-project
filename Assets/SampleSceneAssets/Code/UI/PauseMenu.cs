using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private GameObject[] panelsToDisable;
    [SerializeField] private GameObject pausePanel;

    private void Update()
    {
        if (pauseAction.action.WasPressedThisFrame())
        {
            ChangePauseState();
        }
    }

    public void ChangePauseState()
    {
        if (pausePanel.activeSelf)
            MusicByScore.instance.UnPauseGame();
        else
            MusicByScore.instance.PauseGame();

        Time.timeScale = (pausePanel.activeSelf ? 1f : 0f);
        toggleAllsPanels(pausePanel.activeSelf);
        pausePanel.SetActive(!pausePanel.activeSelf);
    }

    private void toggleAllsPanels(bool toggle)
    {
        foreach (var panel in panelsToDisable)
        {
            panel.SetActive(toggle);
        }
    }
}
