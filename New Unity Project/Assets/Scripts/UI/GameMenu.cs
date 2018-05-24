using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    Animator anim;
    public RectTransform panel;
    public RectTransform loadMain;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void OnPressStart()
    {
        Game.current = new Game();
        anim.Play("FadeAway");
        Invoke("StartSceneLoader", 1.0f);
    }

    public void OnPressLoad()
    {
        panel.gameObject.SetActive(false);
        loadMain.gameObject.SetActive(true);
        
    }

    public void OnPressExit()
    {
        Application.Quit();
    }


    void StartSceneLoader()
    {

        SceneManager.LoadScene(3);
    }

    public void BackButton()
    {
        panel.gameObject.SetActive(true);
        loadMain.gameObject.SetActive(false);

    }
}
