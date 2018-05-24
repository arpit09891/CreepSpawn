using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour {

    public List<GameObject> enemyList;
    public GameObject bunny;
    public GameObject Hellephant;
    public GameObject bear;

    private void Awake()
    {
       
    }
    private void Start()
    {
        if (enemyList == null)
        {
            enemyList = new List<GameObject>();
        }
        else
        {
            if (Game.current.s_enemyList != null)
            {
                foreach (s_Enemy enemy in Game.current.s_enemyList)
                {
                    GameObject tempEnemy = new GameObject();
                    if (enemy.type == "elephant")
                    {
                        SpawnEnemy(Hellephant, enemy.spawnIndex, enemy.laneIndex);
                        tempEnemy = Instantiate(Hellephant, new Vector3(enemy.positionX, enemy.positionY, enemy.positionZ), new Quaternion(0f, 0f, 0f, 0f));
                    }
                    else if (enemy.type == "bear")
                    {
                        SpawnEnemy(bear, enemy.spawnIndex, enemy.laneIndex);
                        tempEnemy = Instantiate(bear, new Vector3(enemy.positionX, enemy.positionY, enemy.positionZ), new Quaternion(0f, 0f, 0f, 0f));
                    }
                    else if (enemy.type == "bunny")
                    {
                        SpawnEnemy(bunny, enemy.spawnIndex, enemy.laneIndex);
                        tempEnemy = Instantiate(bunny, new Vector3(enemy.positionX, enemy.positionY, enemy.positionZ), new Quaternion(0f, 0f, 0f, 0f));
                    }
                   
                    tempEnemy.transform.position = new Vector3(enemy.positionX, enemy.positionY, enemy.positionZ);

                    tempEnemy.GetComponent<EnemyHealth>().currentHealth = enemy.currentHealth;
                    tempEnemy.GetComponent<StateController>().tempName = enemy.type;
                    //Instantiate(tempEnemy, new Vector3(enemy.positionX,enemy.positionY, enemy.positionZ), new Vector3());
                    enemyList.Add(tempEnemy);
                }            }

          
        }
    }
    void SpawnEnemy(GameObject enemy, int spawnIndex, int laneIndex)
    {
        if (spawnIndex == 0)
        {
            enemy.GetComponent<StateController>().wayPointList = GameObject.FindGameObjectWithTag("Lane1").GetComponent<Lanes>().lanePoints;
            //Debug.Log("SpawnPointIndex" + (spawnPointIndex + 1) + "lane1" );
            enemy.GetComponent<StateController>().LaneIndex = laneIndex;
        }
        else if (spawnIndex == 1)
        {
            enemy.GetComponent<StateController>().wayPointList = GameObject.FindGameObjectWithTag("Lane2").GetComponent<Lanes>().lanePoints;
            //Debug.Log("SpawnPointIndex" + (spawnPointIndex + 1) + "lane2");
            enemy.GetComponent<StateController>().LaneIndex = laneIndex;
        }
        else if (spawnIndex == 2)
        {
            enemy.GetComponent<StateController>().wayPointList = GameObject.FindGameObjectWithTag("Lane3").GetComponent<Lanes>().lanePoints;
            //Debug.Log("SpawnPointIndex" + (spawnPointIndex + 1) + "lane3");
            enemy.GetComponent<StateController>().LaneIndex = laneIndex;
        }
       

    }
}
