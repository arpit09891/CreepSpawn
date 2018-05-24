using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {

    public Canvas mainCanvas;
    public RectTransform inMenuPanel;
    public RectTransform saveButtonPanel;
    public RectTransform loadButtonPanel;
    public Text saveNameInputField;

    public void SaveButton () {
        inMenuPanel.gameObject.SetActive(false);
        saveButtonPanel.gameObject.SetActive(true);
	}

    public void LoadButton()
    {
       // Time.timeScale = 1;
        inMenuPanel.gameObject.SetActive(false);
        loadButtonPanel.gameObject.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void SaveGame()
    {
        Game.current.saveName = saveNameInputField.text + " " + System.DateTime.Today;
        SaveLoad.Save();
        Time.timeScale = 1;
        inMenuPanel.gameObject.SetActive(true);
        saveButtonPanel.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(false);
    }
    public void GoToInGameMenu()
    {
        inMenuPanel.gameObject.SetActive(true);
        loadButtonPanel.gameObject.SetActive(false);
        saveButtonPanel.gameObject.SetActive(false);
    }

    public void UnPause()
    {
        mainCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
}
