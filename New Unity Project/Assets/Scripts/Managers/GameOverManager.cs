using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public CastleHealth castleHealth;
    public float restart = 5f;

    public Canvas inGameMenu;
    private string GUImode;

    Animator anim;
    float restartTimer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //in game menu controller
        if (Input.GetKeyDown("escape")) //Pause game when escape is pressed
        {
            Time.timeScale = 0f;
            GUImode = "paused";
            DisplayMenu();
        }

        //game loop
        if (playerHealth.currentHealth <= 0 || castleHealth.currentHealth <=0)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if(restartTimer>=restart)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    public void DisplayMenu()
    {
        if (GUImode == "paused")
        {
            inGameMenu.gameObject.SetActive(true);
            //GUImode = "resume";
        }
    }
}
