using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public string enemyName;

    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    private int enemyCounter;

    EnemyList enemyList;
    //public List<GameObject> EnemyList;
    void Start ()
    {
        enemyList = GetComponent<EnemyList>();
        enemyCounter = 0;
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    public void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        enemyCounter++;
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        //Debug.Log("Spawn PointIndex" + (spawnPointIndex + 1));
        enemy.GetComponent<StateController>().SpawnPointIndex = spawnPointIndex;
        enemy.GetComponent<StateController>().enemyName = enemyName + enemyCounter;
        enemy.GetComponent<StateController>().tempName = enemyName;
        //enemy.GetComponent<EnemyMovement>().UILog = GameObject.Find("Log").GetComponent<UnityEngine.UI.Text>();
        if (spawnPointIndex == 0)
        {
            enemy.GetComponent<StateController>().wayPointList = GameObject.FindGameObjectWithTag("Lane1").GetComponent<Lanes>().lanePoints;
            //Debug.Log("SpawnPointIndex" + (spawnPointIndex + 1) + "lane1" );
            enemy.GetComponent<StateController>().LaneIndex = 1;
        }
        else if (spawnPointIndex == 1)
        {
            enemy.GetComponent<StateController>().wayPointList = GameObject.FindGameObjectWithTag("Lane2").GetComponent<Lanes>().lanePoints;
            //Debug.Log("SpawnPointIndex" + (spawnPointIndex + 1) + "lane2");
            enemy.GetComponent<StateController>().LaneIndex = 2;
        }
        else if (spawnPointIndex == 2)
        {
            enemy.GetComponent<StateController>().wayPointList = GameObject.FindGameObjectWithTag("Lane3").GetComponent<Lanes>().lanePoints;
            //Debug.Log("SpawnPointIndex" + (spawnPointIndex + 1) + "lane3");
            enemy.GetComponent<StateController>().LaneIndex = 3;
        }
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemyList.enemyList.Add(enemy);
    }
}
