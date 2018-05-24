using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CastleHealth : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;
    public float timeRemaining;
    public Text casteHealth;
    public Text timeText;
    public Text ResultText;
    bool gameOver;
    bool isWin;
    GameObject enemy;
    bool enemyinrange;

    // Use this for initialization
    private void Awake()
    {
        currentHealth = maxHealth;
        gameOver = false;
        Game.current.LoadUIData();        
    }
    void Start () {
        casteHealth.text = "Castle Health :" + currentHealth;
        timeText.text = "Time Remaining : " + (int)timeRemaining;
        enemyinrange = false;
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == enemy)
    //    {
    //        playerInRange = true;
    //    }
    //}


    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        playerInRange = false;
    //    }
    //}


    // Update is called once per frame
    void Update () {

        casteHealth.text = "Castle Health :" + currentHealth;
        timeText.text = "Time Remaining : " + (int)timeRemaining;
        if (!gameOver)
        {
            if (currentHealth <= 0)
            {
                timeRemaining = 0;
                currentHealth = 0;
                isWin = false;
                Debug.Log("Game OVer");
                gameOver = true;
            }
            else if (timeRemaining <= 0)
            {
                isWin = true;
                timeRemaining = 0;
                currentHealth = 0;
                gameOver = true;
            }
            else
            {
                timeRemaining -= Time.deltaTime;
            }
        }
        else
        {
            if (isWin)
            {
                ResultText.text = "Victory";
            }
            else
            {
                ResultText.text = "Game Over";
            }

        }
	}

    public void TakeDamage(float damage)
    {
        casteHealth.text = "Castle Health :" + maxHealth;
        if (currentHealth - damage < 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
        }
    }
}
