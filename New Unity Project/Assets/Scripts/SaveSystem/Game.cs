using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Player;

[System.Serializable]
public class Game
{

    public static Game current;
    public s_Player player1;
    public s_Camera camera;
    public s_UIData UI_Data;
    public s_Enemy enemy;
    public string saveName;
    public List<s_Enemy> s_enemyList;
    

    public Game()
    {
        player1 = new s_Player();
        camera = new s_Camera();
        UI_Data = new s_UIData();
        enemy = new s_Enemy();
        s_enemyList = new List<s_Enemy>();

    }

    public void SaveGame()
    {
        savePlayerData();
        saveCameraData();
        saveUIData();
        saveEnemyData();
    }

    public void savePlayerData()
    {
        GameObject gamePlayer = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth playerHealth = gamePlayer.GetComponent<PlayerHealth>();
        player1.positionX = gamePlayer.transform.position.x;
        player1.positionY = gamePlayer.transform.position.y;
        player1.positionZ = gamePlayer.transform.position.z;
        player1.currentHealth = playerHealth.currentHealth;
        Debug.Log(player1.positionX);
        Debug.Log(player1.positionY);
    }
    public void saveEnemyData()
    {
        GameObject[] gameEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        s_Enemy tempEnemy;
        foreach(GameObject gameEnemy in gameEnemies)
        {
            tempEnemy = new s_Enemy();
            EnemyHealth tempHealth = gameEnemy.GetComponent<EnemyHealth>();
            tempEnemy.currentHealth = tempHealth.currentHealth;

            tempEnemy.positionX = gameEnemy.transform.position.x;
            tempEnemy.positionY = gameEnemy.transform.position.y;
            tempEnemy.positionZ = gameEnemy.transform.position.z;

            StateController tempState = gameEnemy.GetComponent<StateController>();
            tempEnemy.type = tempState.tempName;
            tempEnemy.spawnIndex = tempState.SpawnPointIndex;
            tempEnemy.laneIndex = tempState.LaneIndex;

            s_enemyList.Add(tempEnemy);
        }
       
    }
    public void saveCameraData()
    {
        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.positionX = gameCamera.transform.position.x;
        camera.positionY = gameCamera.transform.position.y;
        camera.positionZ = gameCamera.transform.position.z;

        Debug.Log(camera.positionX);
        Debug.Log(camera.positionY);
    }
    public void saveUIData()
    {
        GameObject gameUI = GameObject.FindGameObjectWithTag("Castle");
        CastleHealth tempCasteHealth = gameUI.GetComponent<CastleHealth>();
        UI_Data.currentHealth = tempCasteHealth.currentHealth;
        UI_Data.timer = tempCasteHealth.timeRemaining;
        //UI_Data.score = tempCasteHealth.s
    }

    public void LoadPlayerData()
    {
        GameObject gamePlayer = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth playerHealth = gamePlayer.GetComponent<PlayerHealth>();
        gamePlayer.transform.position = new Vector3(Game.current.player1.positionX, Game.current.player1.positionY, Game.current.player1.positionZ);
        playerHealth.currentHealth = Game.current.player1.currentHealth;
    }

    public void LoadCameraData()
    {
        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");       
        gameCamera.transform.position = new Vector3(Game.current.camera.positionX, Game.current.camera.positionY, Game.current.camera.positionZ);
    }

    public void LoadUIData()
    {
        GameObject gameUI = GameObject.FindGameObjectWithTag("Castle");
        CastleHealth tempCasteHealth = gameUI.GetComponent<CastleHealth>();
        tempCasteHealth.timeRemaining = Game.current.UI_Data.timer;
        tempCasteHealth.currentHealth = Game.current.UI_Data.currentHealth;

    }

   
}