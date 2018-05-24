using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] lanesPoints;
    private Text UILog;
    
    //For Debug 
    public int SpawnPointIndex;
    public int LaneIndex;

    public string enemyName;
    
    float minionSpeed;

    private int targetPosition;
    CastleHealth casteHealth;
    private UnityAction bornListener;
    private UnityAction lifeListener;
    private UnityAction deathListener;
    bool isDieing;
    m_Enemy enemyModel;
    NavMeshAgent nav;

    void Awake ()
    {
        //Debug.Log("SpawnPointIndex" + (SpawnPointIndex + 1) + "LanePointIndex" + LaneIndex);
        targetPosition = 0;
        enemyModel = GetComponent<m_Enemy>();
        bornListener = new UnityAction(MinionSpawned);
        lifeListener = new UnityAction(MinionMovement);
        deathListener = new UnityAction(MinionDied);
        isDieing = false;
        nav = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        EventManager.StartListening(enemyName + "born", bornListener);
        EventManager.StartListening(enemyName + "movement", MinionMovement);
        EventManager.StartListening(enemyName + "death", deathListener);
        
    }

    private void OnDisable()
    {
        EventManager.StopListening(enemyName + "born", bornListener);
        EventManager.StopListening(enemyName + "movement", MinionMovement);
        EventManager.StopListening(enemyName + "death", deathListener);
    }


    private void Start()
    {
        minionSpeed = enemyModel.movementSpeed;
        casteHealth = GameObject.FindGameObjectWithTag("Castle").GetComponent<CastleHealth>();
        UILog = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Text>(true);
       EventManager.TriggerEvent(enemyName + "born");
    }



    void Update ()
    {
       
        if (targetPosition < (lanesPoints.Length))
        {
            if (CheckDistance())
            {
                EventManager.TriggerEvent(enemyName + "movement");
                targetPosition++;
            }
            else
            {
                MoveMinion();
            }
        }
        else if(isDieing == false)
            EndOfPath();
      
    }

    private void MoveMinion()
    {
        nav.SetDestination(lanesPoints[targetPosition].transform.position);
        //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, lanesPoints[targetPosition].transform.position, 0.1f * minionSpeed);
    }

    private bool CheckDistance()
    {
        float distance = Vector3.Distance(gameObject.transform.position, lanesPoints[targetPosition].transform.position);
        if (distance > 0 && distance < 1 )
        {
            return true;
        }

        return false;
    }

    public void EndOfPath()
    {
        EventManager.TriggerEvent(enemyName + "death");
        if (casteHealth.currentHealth > 0)
        {
            casteHealth.TakeDamage(enemyModel.attackDamage);
        }
        gameObject.GetComponent<EnemyHealth>().Death();
        isDieing = true;
    }

    void MinionSpawned()
    {

        UILog.text += enemyName + " spawned at lane " + LaneIndex + "\n";
        //Debug.Log(enemyName + " spawned at lane " + LaneIndex);
    }

    void MinionDied()
    {
        UILog.text += enemyName + " Died" + "\n";
        //Debug.Log(enemyName + " Died");
    }

    void MinionMovement()
    {
        //UILog.text += enemyName + "is at point " + targetPosition + " of Lane" + LaneIndex + "\n";
        //Debug.Log(enemyName + "is at point " + targetPosition + " of Lane" + LaneIndex);
    }

}
